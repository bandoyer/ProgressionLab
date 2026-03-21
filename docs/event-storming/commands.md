# Commands

Blue stickies. Actions that trigger events.

## Commands

### Setup (Actor: Athlete)
1. **SignUp** → AthleteSignedUp
2. **LogIn** → AthleteLoggedIn
3. **SelectPhase** → PhaseSelected (athlete picks which phase of a template to start)
4. **SetStartDate** → StartDateSet
5. **SelectExercises** → ExercisesSelected (athlete fills each exercise slot defined by the selected phase)
6. **ConfirmExerciseSelection** → ExerciseSelectionConfirmed (athlete previews and confirms before generation)

### Setup (Actor: System)
7. **GeneratePhase** → PhaseGenerated (reads the Programming Skeleton + athlete's exercise selections to create weeks)

### Weekly Planning (Actor: Athlete)
8. **EnterE1rm** → E1rmEntered (can enter known weight at any rep count and RPE to bootstrap)
9. **SetWeeklyWeights** → WeeklyWeightsSet (athlete picks target weights for the week, typically 1-5% over prior week)

### Weekly Planning (Actor: System)
10. **CalculateTargetWeights** → TargetWeightsCalculated (e1RM x RPE Percentage Table = target weights for all rep/RPE combos)

### Training (Actor: Athlete)
11. **RecordSet** → SetCompleted (one set at a time: weight, reps, RPE for sets at RPE 6+)
12. **RecordBackOffSet** → BackOffSetCompleted (load drop or repeat after top set)
13. **CompleteTrainingDay** → TrainingDayCompleted (includes session duration and sRPE)
14. **CompleteGppElement** → GppElementCompleted

### Training (Actor: System)
15. **CalculateE1rm** → E1rmAutoCalculated (derived from logged set: weight / rpePercentage(reps, rpe), rounded to 0.5)

### Progression (Actor: Athlete)
16. **RepeatWeek** → WeekRepeated (continue repeating the target week)
17. **AddWeek** → AdditionalWeekAdded
18. **AdvancePhase** → PhaseCompleted + PhaseSelected (athlete decides to move to next phase)

### Progression (Actor: System)
19. **DetectStall** → E1rmStalled (system notices e1RM is no longer increasing)
20. **RecommendAdvance** → PhaseAdvanceTriggered (system recommends advancing when 2+ lifts stall, athlete decides)

## Needs more discussion
- How does the athlete interact with the calculator during weekly planning? Is it a separate screen or integrated into the training day view?
- When the system recommends advancing, is it a notification, a banner, or a modal? (UI concern, but affects the command flow)
