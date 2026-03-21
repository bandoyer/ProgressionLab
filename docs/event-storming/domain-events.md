# Domain Events

Orange stickies. Things that happen in the domain.

## Events (rough time order)

### Setup
1. **AthleteSignedUp** - A new athlete creates an account
2. **AthleteLoggedIn** - An athlete signs into the system
3. **PhaseSelected** - An athlete chose a phase from a template (e.g. Phase 1 of the Beginner Template)
4. **StartDateSet** - The athlete entered the Sunday date for week 1
5. **ExercisesSelected** - The athlete chose exercises for each exercise slot defined by the selected phase (slots vary per phase)
6. **ExerciseSelectionConfirmed** - The athlete reviewed and confirmed their exercise choices
7. **PhaseGenerated** - The system created the weeks, training days, GPP elements, and prescriptions by reading from the Programming Skeleton and applying the athlete's exercise selections

### Weekly Planning (before training)
8. **E1rmEntered** - The athlete entered or updated their estimated 1RM for an exercise into the calculator (can enter known weight at any rep count and RPE, not just a true 1RM)
9. **TargetWeightsCalculated** - The system generated target weights for all rep/RPE combinations using e1RM x RPE Percentage Table
10. **WeeklyWeightsSet** - The athlete selected target weights for the upcoming week's exercises (1-5% increase over prior week recommended)

### Training (in the gym)
11. **SetCompleted** - The athlete completed a single set and logged weight, reps, and RPE (for sets at RPE 6+)
12. **BackOffSetCompleted** - The athlete completed a load drop or repeat set after the top set
13. **E1rmAutoCalculated** - The system derived a new e1RM from the logged set data using the RPE Percentage Table
14. **TrainingDayCompleted** - The athlete finished all exercises for a training day, logging session duration and session RPE (sRPE)
15. **GppElementCompleted** - The athlete completed a GPP element (conditioning, upper back, trunk, or arm work)

### Progression
16. **WeekCompleted** - All training days and GPP elements for a week are done
17. **WeekRepeated** - The athlete repeated the target week (week 4) because e1RMs are still trending up
18. **E1rmStalled** - An exercise's e1RM is no longer increasing week over week
19. **PhaseAdvanceTriggered** - Two or more lifts' e1RMs have stalled or regressed, signaling time to move to the next phase (recommendation, not enforcement)
20. **AdditionalWeekAdded** - The athlete chose to add another week to the current phase
21. **PhaseCompleted** - The athlete decided to move on from the current phase (either by choice or after stalling)
22. **TemplateCompleted** - The athlete finished all phases in the template

## Needs more discussion
- Dan's notes say the athlete determines weight increases from the prior week's workout day. How exactly does that flow work in the app? Do they see last week's results and adjust?
- Should "WeekRepeated" be an explicit event or just the absence of advancing?
- How does the supplement slot work as an event? Is it part of TrainingDayCompleted or separate?
