using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotReaper;
using NotReaper.Targets;
using NotReaper.UI;
using NotReaper.Managers;
using NotReaper.Models;
using NotReaper.Timing;
using System.Linq;

public class LowerDifficultyGenerator : MonoBehaviour
{
    /// index   
    ///         0 = expert
    ///         1 = advanced
    ///         2 = standard
    ///         3 = beginner

    public static LowerDifficultyGenerator Instance = null;
    public GameObject window;
    public GameObject confirmButton;
    public GameObject cancelButton;

    private void Start()
    {
        if (Instance is null) Instance = this;
        else
        {
            Debug.LogWarning("LowerDifficultyManager already exists.");
            return;
        }
        if (PlayerPrefs.HasKey("l_diffs"))
        {
            if (PlayerPrefs.GetInt("l_diffs") == 1) Activate();
        }
        else
        {
            window.SetActive(false);
        }
    }

    public void Activate()
    {
        window.SetActive(true);
        confirmButton.SetActive(false);
        cancelButton.SetActive(false);
    }

    public void OnDownmapClicked()
    {
        EnableButtons(true);
    }

    public void OnConfirmClicked()
    {
        EnableButtons(false);
        GenerateDifficulty(DifficultyManager.I.loadedIndex);
    }

    public void OnCancelClicked()
    {
        EnableButtons(false);
    }

    private void EnableButtons(bool enable)
    {
        confirmButton.SetActive(enable);
        cancelButton.SetActive(enable);
    }

    public void GenerateDifficulty(int index)
    {
        if (!CanGenerate())
        {
            NRNotification notification = new NRNotification("Can't generate difficulty: No notes available.", NRNotifType.Fail);
            NotificationShower.Queue(notification);
            return;
        }
        Timeline.instance.SortOrderedList();
        switch (index)
        {
            case 1:
                GenerateAdvanced(Timeline.orderedNotes);
                break;
            case 2:
                GenerateStandard(Timeline.orderedNotes);
                break;
            case 3:
                GenerateBeginner(Timeline.orderedNotes);
                break;
            default:
                break;
        }
    }
    private void GenerateAdvanced(List<Target> targets)
    {
        
        DeleteStreams(targets, 3, 120, 60);
        
        EnforceSlotsLeadinTime(targets);
        EnforcePauseAfterChains(targets, 480, true);
        EnforcePauseAfterSustains(targets, 480);

        DistanceConstraint conSixteenth = new DistanceConstraint(120, 1f);
        DistanceConstraint conEigth = new DistanceConstraint(240, 2f);
        DistanceConstraint conQuarter = new DistanceConstraint(480, 3f);
        DistanceConstraint conQuarterDot = new DistanceConstraint(720, 4f);
        DistanceConstraint conHalf = new DistanceConstraint(960, 5f);

        
        EnforceDistanceBetweenSingleTargets(targets, conSixteenth, conEigth, conQuarter, conQuarterDot, conHalf);
        
        EnforceDistanceBetweenDoubles(targets, 4f, false);

        Debug.Log("Generated advanced.");
    }

    private void GenerateStandard(List<Target> targets)
    {
        ConvertSlots(targets);
        
        DeleteStreams(targets, 2, 240, 120);
        
        EnforcePauseBeforeDoubles(targets, 960);
        EnforcePauseBeforeChains(targets, 960);
        EnforcePauseAfterChains(targets, 960, false);
        EnforceChainIsolation(targets);
        EnforcePauseAfterSustains(targets, 960);
        EnforcePauseBeforeMelees(targets, 960);
        EnforcePauseAfterMelees(targets, 960);
        ConvertShortSustains(targets);
        DistanceConstraint conSixteenth = new DistanceConstraint(120, 1f);
        DistanceConstraint conEigth = new DistanceConstraint(240, 2f);
        DistanceConstraint conQuarter = new DistanceConstraint(480, 2f);
        DistanceConstraint conHalf = new DistanceConstraint(960, 3f);
        
        EnforceDistanceBetweenSingleTargets(targets, conSixteenth, conEigth, conQuarter, conHalf);
        
        EnforceDistanceBetweenDoubles(targets, 3f, true);
        

        Debug.Log("Generated standard.");
    }

    private void GenerateBeginner(List<Target> targets)
    {
        DeleteMelees(targets);
        ConvertSlots(targets);
        ConvertAllChainsToTargets(targets);
        CleanupChains(targets);
        EnforcePauseAfterSustains(targets, 480);
        
        DeleteStreams(targets, 2, 480, 240);
        
        UncrossAllTargets(targets);
        DistanceConstraint constraint = new DistanceConstraint(480, 1.5f);
        DistanceConstraint constraint2 = new DistanceConstraint(960, 3f);
        
        EnforceDistanceBetweenSingleTargets(targets, constraint, constraint2);
        
        EnforceDistanceBetweenDoubles(targets, 2f, true);
        Debug.Log("Generated beginner.");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                GenerateDifficulty(DifficultyManager.I.loadedIndex);
            }
        }
    }

    private void ConvertShortSustains(List<Target> targets)
    {
        for(int i = 0; i < targets.Count -1; i++)
        {
            var target = targets[i];
            if (target.data.behavior != TargetBehavior.Hold) continue;

            if(target.data.beatLength.tick <= 480)
            {
                var velocity = target.data.velocity;
                target.data.behavior = TargetBehavior.Standard;
                target.data.velocity = velocity;
            }
        }
    }

    private void UncrossAllTargets(List<Target> targets)
    {
        for(int i = 0; i < targets.Count - 1; i++)
        {
            var target = targets[i];
            if (!IsRegularNote(target)) continue;
            if(i + 1 < targets.Count)
            {
                var nextTarget = targets[i + 1];
                if (target.data.x < nextTarget.data.x && target.data.handType == TargetHandType.Right)
                {
                    target.data.x *= -1;
                    nextTarget.data.x *= -1;
                }
                else if (target.data.x > nextTarget.data.x && target.data.handType == TargetHandType.Left)
                {
                    nextTarget.data.x *= -1;
                    target.data.x *= -1;
                }
            }
        }
    }

    private void DeleteMelees(List<Target> targets)
    {
        for(int i = targets.Count - 1; i >= 0; i--)
        {
            var target = targets[i];
            if (target.data.behavior != TargetBehavior.Melee) continue;
            Timeline.instance.DeleteTarget(target);
        }
    }

    private void CleanupChains(List<Target> targets)
    {
        for(int i = targets.Count - 1; i >= 0; i--)
        {
            var target = targets[i];
            if (target.data.behavior == TargetBehavior.Chain)
            {
                Timeline.instance.DeleteTarget(target);
            }
            else if(target.data.behavior == TargetBehavior.ChainStart || target.data.behavior == TargetBehavior.NR_Pathbuilder)
            {
                var velocity = target.data.velocity;
                target.data.behavior = TargetBehavior.Standard;
                target.data.velocity = velocity;
            }
        }
    }

    private void ConvertSlots(List<Target> targets)
    {
        for(int i = 0; i < targets.Count - 1; i++)
        {
            var target = targets[i];
            if (IsSlot(target, out _))
            {
                var velocity = target.data.velocity;
                target.data.behavior = TargetBehavior.Standard;
                target.data.velocity = velocity;
            }
        }
    }

    private void EnforcePauseBeforeMelees(List<Target> targets, ulong pauseLength)
    {
        for(int i = targets.Count -1; i >= 0; i--)
        {
            if (i == 0) break;
            var target = targets[i];
            if (target.data.behavior != TargetBehavior.Melee) continue;
            if(i - i >= 0)
            {
                var nextTarget = targets[i - 1];
                if (nextTarget.data.behavior == TargetBehavior.Melee) continue;
                if (nextTarget.data.time == target.data.time)
                {
                    Timeline.instance.DeleteTarget(target);
                    continue;
                }
                var timeBetween = GetTicksBetweenTargets(target, nextTarget);
                var pause = GetCheckValue(pauseLength, target);
                if(timeBetween < pause)
                {
                    if(target.data.time.tick % 960 == 0)
                    {
                        if(nextTarget.data.behavior == TargetBehavior.Chain)
                        {
                            Timeline.instance.DeleteTarget(target);
                        }
                        else
                        {
                            Timeline.instance.DeleteTarget(nextTarget);
                        }
                    }
                    else
                    {
                        Timeline.instance.DeleteTarget(target);
                    }
                }
            }
        }
    }

    private void EnforcePauseAfterMelees(List<Target> targets, ulong pauseLength)
    {
        for (int i = targets.Count - 1; i >= 0; i--)
        {
            if (i == 0) break;
            var target = targets[i];
            if (target.data.behavior != TargetBehavior.Melee) continue;
            if (i + 1 >= targets.Count) continue;

            var nextTarget = targets[i + 1];
            if (nextTarget.data.behavior == TargetBehavior.Melee) continue;
            var pause = GetCheckValue(pauseLength, target);
            var duration = GetTicksBetweenTargets(target, nextTarget);
            if (duration < pause)
            {
                if(nextTarget.data.behavior == TargetBehavior.Melee)
                {
                    if (duration.tick >= pause.tick / 2) continue;
                }
                if(nextTarget.data.behavior == TargetBehavior.Chain)
                {
                    Timeline.instance.DeleteTarget(target);
                }
                else
                {
                    Timeline.instance.DeleteTarget(nextTarget);
                }
            }
            
        }
    }

    private void EnforcePauseAfterSustains(List<Target> targets, ulong pauseLength)
    {
        for(int i = 0; i < targets.Count - 1; i++)
        {
            if (i + 1 >= targets.Count) break;
            var target = targets[i];
            if (target.data.behavior != TargetBehavior.Hold) continue;
            var nextTarget = targets[i + 1];
            if (target.data.handType != nextTarget.data.handType) continue;
            var timeBetween = GetTicksBetweenTargets(target, nextTarget);
            var pause = GetCheckValue(pauseLength, target);
            if(timeBetween < pause)
            {
                var newLength = pause.tick - timeBetween.tick;
                if(target.data.beatLength.tick - newLength <= 240)
                {
                    target.data.behavior = TargetBehavior.Standard;
                }
                else
                {
                    target.data.beatLength -= new QNT_Duration(newLength);
                }
            }

        }
    }

    private void EnforceChainIsolation(List<Target> targets)
    {
        for (int i = targets.Count - 1; i >= 0; i--)
        {
            if (i == 0) break;
            var target = targets[i];
            if (target.data.behavior != TargetBehavior.ChainStart && target.data.behavior != TargetBehavior.NR_Pathbuilder) continue;
            GetChainDuration(targets, i, out int chainLength);
            IsolateChain(targets, i, chainLength);
        }
    }

    private void IsolateChain(List<Target> targets, int chainStartIndex, int chainLength)
    {
        TargetHandType handType = targets[chainStartIndex].data.handType;
        for (int i = chainStartIndex + chainLength - 1; i >= chainStartIndex; i--)
        {
            var target = targets[i];
            if (target.data.handType == handType) continue;
            if (target.data.behavior == TargetBehavior.ChainStart || target.data.behavior == TargetBehavior.NR_Pathbuilder) continue;
            Timeline.instance.DeleteTarget(target);
        }
    }

    private void EnforcePauseBeforeDoubles(List<Target> targets, ulong pauseLength)
    {
        for (int i = targets.Count - 1; i >= 0; i--)
        {
            if (i == 0) break;
            var target = targets[i];
            if (!IsRegularNote(target, true)) continue;
            if (targets[i - 1] != null)
            {
                var nextTarget = targets[i - 1];
                if (!IsRegularNote(target, true)) continue;
                if (target.data.time != nextTarget.data.time) continue;
                if(i - 2 >= 0)
                {
                    var nextNextTarget = targets[i - 2];
                    if (!IsRegularNote(target, true)) continue;
                    if(i - 3 >= 0)
                    {
                        var nextNextNextTarget = targets[i - 3];
                        if (!IsRegularNote(target, true)) continue;
                        if (nextNextTarget.data.time == nextNextNextTarget.data.time) continue;                       
                    }

                    var pause = GetCheckValue(pauseLength, nextNextTarget);
                    var duration = GetTicksBetweenTargets(nextTarget, nextNextTarget);
                    if (duration < pause)
                    {
                        if(nextNextTarget.data.behavior == TargetBehavior.Chain)
                        {
                            Timeline.instance.DeleteTarget(nextTarget);
                            Timeline.instance.DeleteTarget(target);
                        }
                        else
                        {
                            Timeline.instance.DeleteTarget(nextNextTarget);
                        }
                    }

                }
            }
        }
    }

    private void EnforcePauseBeforeChains(List<Target> targets, ulong pauseLength)
    {
        for(int i = targets.Count -1; i >= 0; i--)
        {
            if (i == 0) break;
            var target = targets[i];
            if (target.data.behavior != TargetBehavior.ChainStart && target.data.behavior != TargetBehavior.NR_Pathbuilder) continue;
            var chainDuration = GetChainDuration(targets, i, out int length);
            if(chainDuration.tick <= 960)
            {
                ConvertChainToTarget(targets, i, length);
            }
            else if (targets[i - 1] != null)
            {
                var nextTarget = targets[i - 1];
                if (nextTarget.data.behavior == TargetBehavior.Chain) continue;
                var pause = GetCheckValue(pauseLength, target);
                var duration = GetTicksBetweenTargets(target, nextTarget);
                if (duration < pause)
                {
                    Timeline.instance.DeleteTarget(nextTarget);
                }
            }
        }
    }

    private void ConvertAllChainsToTargets(List<Target> targets)
    {
        for (int i = targets.Count - 1; i >= 0; i--)
        {
            var target = targets[i];
            if (target.data.behavior == TargetBehavior.ChainStart || target.data.behavior == TargetBehavior.NR_Pathbuilder)
            {
                Debug.Log("Found chain");
                var chainDuration = GetChainDuration(targets, i, out int chainLength);
                Debug.Log("Chain duration: " + chainDuration);
                Debug.Log("Chain length: " + chainLength);
                if (chainDuration.tick <= 960)
                {
                    ConvertChainToTarget(targets, i, chainLength);
                }
                else
                {
                    ConvertChainToTarget(targets, i, chainLength, true, chainDuration.tick);
                }
            }
           
        }
    }

    private void ConvertChainToTarget(List<Target> targets, int chainStartIndex, int chainLength, bool convertToSustain = false, ulong duration = 120)
    {
        TargetHandType handType = targets[chainStartIndex].data.handType;
        for (int i = chainStartIndex + chainLength; i >= chainStartIndex; i--)
        {
            var target = targets[i];
            if (target.data.handType != handType) continue;
            if (target.data.handType == handType && target.data.behavior != TargetBehavior.Chain && target.data.behavior != TargetBehavior.ChainStart) break;
            if(target.data.behavior == TargetBehavior.ChainStart || target.data.behavior == TargetBehavior.NR_Pathbuilder)
            {
                var velocity = target.data.velocity;
                if (convertToSustain)
                {
                    target.data.behavior = TargetBehavior.Hold;
                    target.data.beatLength = new QNT_Duration(duration);
                }
                else
                {
                    target.data.behavior = TargetBehavior.Standard;
                }
                target.data.velocity = velocity;
            }
            else
            {
                Timeline.instance.DeleteTarget(target);
            }
        }
    }

    private QNT_Timestamp GetChainDuration(List<Target> targets, int chainStartIndex, out int length)
    {
        int endIndex = 0;
        length = 1;
        TargetHandType handType = targets[chainStartIndex].data.handType;
        for(int i = chainStartIndex + 1; i < targets.Count - 1; i++)
        {
            if (targets[i].data.handType != handType) continue;
            if (targets[i].data.behavior != TargetBehavior.Chain) break;
            endIndex = i;
            length++;
        }
        return GetTicksBetweenTargets(targets[chainStartIndex], targets[endIndex]);
    }

    private string EnforcePauseAfterChains(List<Target> targets, ulong pauseLength, bool onlySameHand)
    {
        int count = 0;
        for(int i = targets.Count - 1; i >= 0; i--)
        {
            if (i == 0) break;
            var target = targets[i];
            if (!IsRegularNote(target, true)) continue;       
            if(targets[i - 1] != null)
            {
                var nextTarget = targets[i - 1];
                if (nextTarget.data.behavior != TargetBehavior.Chain) continue;
                if (target.data.handType != nextTarget.data.handType && onlySameHand) continue;
                var pause = GetCheckValue(pauseLength, target);
                var duration = GetTicksBetweenTargets(target, nextTarget);
                if(duration < pause)
                {
                    if (nextTarget.data.behavior == TargetBehavior.ChainStart) continue;
                    if(i - 2 > 0)
                    {
                        
                        var nextNextTarget = targets[i - 2];
                        if (nextNextTarget.data.behavior != TargetBehavior.Chain)
                        {
                            if (i - 3 > 0) nextNextTarget = targets[i - 3];
                        }
                        if (nextNextTarget.data.behavior == TargetBehavior.Chain)
                        {
                            var distBetweenChains = GetTicksBetweenTargets(nextTarget, nextNextTarget);
                            if (distBetweenChains == duration)
                            {
                                var velocity = target.data.velocity;
                                target.data.behavior = TargetBehavior.Chain;
                                target.data.handType = nextTarget.data.handType;
                                target.data.velocity = velocity;
                                Vector2 posDiff = nextTarget.data.position - nextNextTarget.data.position;
                                target.data.position = nextTarget.data.position + posDiff;
                                continue;
                            }
                        }
                        
                        
                    }
                    Timeline.instance.DeleteTarget(target);
                    count++;
                }
            }
            
        }
        return $"Deleted {count} notes";
    }

    private string EnforceDistanceBetweenDoubles(List<Target> targets, float maxDistance, bool fixCrossovers)
    {
        int count = 0;
        for (int i = 0; i < targets.Count - 1; i++)
        {
            if (targets[i + 1] is null) break;
            var target = targets[i];
            var nextTarget = targets[i + 1];

            //Decrease distance on doubles
            if (target.data.time == nextTarget.data.time)
            {
                if (IsRegularNote(target, true) && IsRegularNote(nextTarget, true))
                {
                    if (fixCrossovers)
                    {
                        if((target.data.position.x < nextTarget.data.position.x && target.data.handType == TargetHandType.Right) ||
                            (target.data.position.x > nextTarget.data.position.x && target.data.handType == TargetHandType.Left))
                        {
                            Timeline.instance.SwapTargets(new List<Target>() { target, nextTarget });
                        }
                    }
                    DecreaseDistance(target, nextTarget, maxDistance);
                }
            }
        }
        return $"Decreased distance on {count} doubles";
    }

    private void EnforceDistanceBetweenSingleTargets(List<Target> targets, params DistanceConstraint[] constraints)
    {
        List<DistanceConstraint> sortedConstraints = constraints.ToList();
        int count = 0;
        for(int i = 0; i < targets.Count -1; i++)
        {
            if (targets[i + 1] is null) break;
            var target = targets[i];
            if (!IsRegularNote(target, true)) continue;
            var nextTarget = targets[i + 1];
            if (!IsRegularNote(nextTarget, true)) continue;
            if (target.data.time == nextTarget.data.time) continue;
            var constraint = GetAppropriateConstraint(GetTicksBetweenTargets(target, nextTarget), sortedConstraints);
            Target nextNextTarget = null;
            if(i + 2 < targets.Count)
            {
                nextNextTarget = targets[i + 2];
                if(IsRegularNote(nextNextTarget, true))
                {
                    if (nextNextTarget.data.time != nextTarget.data.time)
                    {
                        nextNextTarget = null;
                    }
                }
                else
                {
                    nextNextTarget = null;
                }
            }
            
            count++;
            DecreaseDistance(target, nextTarget, constraint.distance);
            
        }
    }

    private DistanceConstraint GetAppropriateConstraint(QNT_Timestamp timeBetween, List<DistanceConstraint> constraints)
    {
        return constraints.Aggregate((c1, c2) => Mathf.Abs(c1.timeBetween - timeBetween.tick) < Mathf.Abs(c2.timeBetween - timeBetween.tick) ? c1 : c2);
    }

    private void DeleteStreams(List<Target> targets, int maxAllowed, ulong maxTimeBetween, ulong cutoff)
    {
        int count = 0;
        int deletedNotes = 0;
        for (int i = targets.Count - 1; i >= 0; i--)
        {
            if (i == 0) break;
            var target = targets[i];
            if (!IsRegularNote(target, true)) continue;
            var ticks = GetCheckValue(maxTimeBetween, target);
            var nextTarget = targets[i - 1];
            if (!IsRegularNote(nextTarget, true)) continue;
            QNT_Timestamp duration = GetTicksBetweenTargets(target, nextTarget);
            count++;
            if(duration.tick <= cutoff)
            {
                count = maxAllowed;
            }
            else if(duration > ticks)
            {
                count = 0;
            }
            if(count >= maxAllowed)
            {
                if (target.data.time.tick % 960 == 0) Timeline.instance.DeleteTarget(nextTarget);
                else if (nextTarget.data.time.tick % 960 == 0) Timeline.instance.DeleteTarget(target);
                else if (target.data.time.tick % 480 == 0) Timeline.instance.DeleteTarget(nextTarget);
                else Timeline.instance.DeleteTarget(target);
                //else if (nextTarget.data.time.tick % 480 == 0) Timeline.instance.DeleteTarget(target);

                deletedNotes++;
                count = 0;
            }
        }
        if (deletedNotes > 0) DeleteStreams(targets, maxAllowed, maxTimeBetween, cutoff);
        //return $"Deleted {deletedNotes} notes";
    }

    private string EnforceSlotsLeadinTime(List<Target> targets)
    {
        int count = 0;
        int convertCount = 0;
        for(int i = targets.Count - 1; i >= 0; i--)
        {
            if (i == 0) break;
            var target = targets[i];
            if (IsSlot(target, out bool isHorizontal))
            {
                var nextTarget = targets[i - 1];
                if (IsSlot(nextTarget, out bool isNextHorizontal))
                {
                    if(isHorizontal == isNextHorizontal) continue;
                }

                var duration = GetTicksBetweenTargets(target, nextTarget);
                var ticks = GetCheckValue((ulong)(isHorizontal ? 960 : 480), target);
                if(duration < ticks)
                {
                    if(nextTarget.data.behavior == TargetBehavior.Chain)
                    {
                        var velocity = target.data.velocity;
                        target.data.behavior = TargetBehavior.Standard;
                        target.data.velocity = velocity;
                        convertCount++;
                    }
                    else
                    {
                        Timeline.instance.DeleteTarget(nextTarget);
                        count++;
                    }
                    
                }
            }
        }
        return $"Deleted {count} notes, converted {convertCount} notes";
    }

    //Double values if tempo > 150
    private QNT_Timestamp GetCheckValue(ulong defaultValue, Target target)
    {
        var tempo = Timeline.instance.GetBpmFromTime(target.data.time);
        ulong val = tempo >= 150d ? defaultValue * 2 : defaultValue;
        return new QNT_Timestamp(val);
    }

    //Get ticks between 2 targets
    private QNT_Timestamp GetTicksBetweenTargets(Target target1, Target target2)
    {
        ulong t1 = target1.data.time.tick;
        if (target1.data.supportsBeatLength) t1 += target1.data.beatLength.tick;
        ulong t2 = target2.data.time.tick;
        ulong diff = t1 > t2 ? t1 - t2 : t2 - t1;
        return new QNT_Timestamp(diff);
    }
    private void DecreaseDistance(Target target1, Target target2, float distance, Target target3 = null)
    {
        for(int i = 0; i < 10; i++)
        {
            if (!IsDistanceBigger(target1, target2, distance)) break;            
            //Timeline.instance.Scale(new List<Target>() { target1 }, 0.9f);
            //target1.data.position *= .9f;
            target2.data.position = Vector2.Lerp(target2.data.position, target1.data.position, 0.2f);
            if (target3 != null) target3.data.position = Vector2.Lerp(target3.data.position, target1.data.position, 0.2f);
            //if (target3 != null) Timeline.instance.Scale(new List<Target>() { target3 }, .9f);
            
        }
        
    }

    private bool IsDistanceBigger(Target target1, Target target2, float distance)
    {
        var cue1 = target1.ToCue();
        var cue2 = target2.ToCue();
        //horizontal distance
        var horizontal = Mathf.Abs(cue1.pitch % 12 - cue2.pitch % 12);
        //vertical distance
        var vertical = Mathf.Abs((cue1.pitch / 11) - (cue2.pitch / 11));
        //combined distance
        if (distance <= 1f) distance += 1f;
        var combined = (distance - 1) * 2f;

        return horizontal > distance || vertical > distance || (horizontal + vertical) > combined;
    }

    private bool CanGenerate()
    {
        return Timeline.orderedNotes.Count > 0;
    }

    private bool IsRegularNote(Target target, bool includeChainStart = false)
    {
        return target.data.behavior != TargetBehavior.Melee && 
            target.data.behavior != TargetBehavior.Chain && 
            target.data.behavior != TargetBehavior.Mine && 
            (includeChainStart ? target.data.behavior != TargetBehavior.ChainStart : true);
    }

    private bool IsSlot(Target target, out bool isHorizontal)
    {
        isHorizontal = target.data.behavior == TargetBehavior.Horizontal;
        return target.data.behavior == TargetBehavior.Horizontal || target.data.behavior == TargetBehavior.Vertical;
    }

    private struct DistanceConstraint
    {
        public ulong timeBetween;
        public float distance;

        public DistanceConstraint(ulong timeBetween, float distance)
        {
            this.timeBetween = timeBetween;
            this.distance = distance;
        }
    }
}
