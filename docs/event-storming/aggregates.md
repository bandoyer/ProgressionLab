# Aggregates

Yellow stickies. Clusters of domain concepts that form consistency boundaries.

## Emerging aggregates

1. **Athlete** - The person training. Owns their account, their phases, their logged data.
2. **Template** - The overall program definition (e.g. "Beginner Template"). Contains one or more Phases. Each phase has its own Programming Skeleton that defines the exercise slots, prescriptions, and GPP programming for every week. The template is reference data.
3. **Phase** - A structured training period within a template (e.g. Phase 1, Phase 2, Phase 3). Each phase has 4 weeks of unique programming with distinct exercise variation, intensity levels, and volume. Week 4 is repeatable. Phases 2 and 3 start with a deload week (built into week 1 of the phase). Each phase defines its own set of exercise slots, which change across phases:
   - Phase 1: simpler slots (Squat, Vertical Press, Horizontal Press, Deadlift, Row)
   - Phase 2: Main/Supplemental/Accessory distinctions (Main Squat, Supplemental Squat, Accessory Squat, etc.)
   - Phase 3: same as Phase 2 but with more variation and 1-rep work
4. **Week** - A 7-day period within a phase, starting on Sunday. Contains training days and GPP elements. A week only makes sense in the context of a phase. (Not its own aggregate, it's an entity within Phase.) Can be repeated (week 4.2, 4.3, etc.).
5. **TrainingDay** - A single day's workout within a week. Contains 3 prescribed exercises plus a supplement slot (optional GPP or conditioning). Also tracks session duration and session RPE (sRPE). The athlete's logged performance lives here. Each day has exercises from different movement categories.
6. **Exercise** - A value object. A specific movement (e.g. "Low Bar Back Squat"). Has a movement category (Squat/Press/Deadlift) and a role that varies by phase (Main/Supplemental/Accessory/Horizontal). Selected by the athlete from a dropdown of options defined by the phase's exercise slots.
7. **Set** - A value object within a TrainingDay exercise. Contains the prescription (target reps, target RPE, target intensity %) and the actuals (weight used, reps completed, actual RPE). Types of sets:
   - **Work set** - a regular prescribed set (e.g. "4 reps @ RPE 7")
   - **Load drop** - back-off set at reduced weight (e.g. "-5% from top set")
   - **Repeat** - back-off set at the same weight as the top set
   - **Myo-rep set** - activation set followed by short-rest mini-sets (may only appear in later templates)
8. **Prescription** - A value object. What the program tells the athlete to do for a set. Format varies by phase complexity:
   - Simple: "4 reps @ RPE 8 x 1 set"
   - With percentage: "4 reps @ RPE 8 (84%) x 1 set"
   - With back-offs: "4 reps @ RPE 9, then -5% for 2-3 sets until RPE 9"
   - With singles: "1 rep @ RPE 8, then 5 reps @ RPE 9 x 1 set"
9. **Programming Skeleton** - Reference data within the Template. The master definition of what exercises, prescriptions, and GPP go where for every week of every phase. The Overview and Weekly tabs are derived from this. In the app, this is the data that drives phase generation.

## RPE Calculator (Domain Service)
The RPE Calculator is a stateless calculation, not an aggregate. It uses:
- An **RPE Percentage Table** (reference data): RPE (6.5-10 in 0.5 increments) x Reps (1-10) = percentage of 1RM. This table is constant across all templates.
- An **RPE Coefficient formula**: `0.0005x² - 0.0342x + 1.025` (used to derive the table values).
- **e1RM calculation**: Takes a known weight at a known reps and RPE, divides by the corresponding percentage to derive e1RM. Uses MAX across multiple inputs if provided. Result rounded to nearest 0.5.
- **Target weight calculation**: `e1RM x rpePercentage(targetReps, targetRPE)` = target weight for a given prescription.

## GPP elements (within Week)
GPP is performed during the week but is flexible on timing. The system recommends when, the athlete can adjust. Four types:
- **Conditioning** - HIIT or LISS cardio. Has duration and intensity (RPE). Phase 1 starts with 1x/wk LISS only; later phases add HIIT and increase frequency.
- **Upper Back Work** - Exercises like pull-ups, rows. Not present in Phase 1 week 1.
- **Trunk Work** - Core/ab exercises, often isometric. Not present in Phase 1 week 1.
- **Arm Work** - Biceps and triceps, performed as supersets. Not present in Phase 1 week 1.

GPP prescriptions come in two flavors:
- **Time-priority** - AMRAP for X minutes (e.g. "7 min AMRAP of Upper Back Work 2x/wk")
- **Task-priority** - X sets of Y reps @ RPE (e.g. "2 sets of 12-20 reps @ RPE 8 2x/wk")

## Needs more discussion
- Where does the AU/CU ratio (acute/chronic workload) live? It's derived from session duration x sRPE across weeks. Is it a read model or part of the Phase?
- The Analysis tab auto-populates volume, average intensity, and e1RM trends. This feels like a read model/projection, not an aggregate.
