# Aggregates

Yellow stickies. Clusters of domain concepts that form consistency boundaries.

## Aggregates

### Program (aggregate root)
The overall program definition (e.g. "Beginner Template", "Strength I"). Lifters and coaches call these "programs" or "programming" — this is the ubiquitous language. A Program is always created and modified as a whole. You never mix pieces across Programs or load internal parts independently.

Contains the full structure:

- **Program** (aggregate root)
  - has one or more **Blocks** (entity)
    - has one or more **Weeks** (entity)
      - has one or more **Slots** (entity)
        - has a **Prescription** (value object)

#### Block
A structured training period within a Program (e.g. Block 1/Introductory, Block 2/Developmental, Block I, Block II). Each block has distinct goals, exercise variation, intensity levels, and volume. Blocks may start with a deload week. Each block defines its own set of exercise slots, which can change across blocks:
- Beginner Block 1: simpler slots (Squat, Vertical Press, Horizontal Press, Deadlift, Row)
- Beginner Block 2: Main/Supplemental/Accessory distinctions
- Strength I Block I/II: muscle-group labeled slots (Quad 1, Quad II, Chest I, etc.)

#### Week
A 7-day period within a Block. A Week only makes sense in the context of a Block. Can be repeated (week 4.2, 4.3, etc.). Contains training days and GPP elements.

#### Slot
A numbered, exercise-agnostic position within a Week. The skeleton defines what volume/intensity prescription each slot gets. Exercise Selection (separate from the skeleton) assigns a specific movement to each slot. This separation allows the same prescription structure to work across different exercise choices.

#### Prescription
A value object. What the program tells the athlete to do for a slot. Format varies by program complexity:
- Simple: "4 reps @ RPE 8 x 1 set"
- With percentage: "4 reps @ RPE 8 (84%) x 1 set"
- With back-offs: "4 reps @ RPE 9, then -5% for 2-3 sets until RPE 9"
- With singles: "1 rep @ RPE 8, then 5 reps @ RPE 9 x 1 set"

### Athlete
The person training. Owns their account and their logged data. Separate aggregate from Program.

### Other domain concepts (not yet modeled)

- **TrainingDay** - A single day's workout within a week. Contains prescribed exercises plus GPP. Tracks session duration and session RPE (sRPE). The athlete's logged performance lives here.
- **Exercise** - A value object. A specific movement (e.g. "Low Bar Back Squat"). Has a movement category (Squat/Press/Deadlift) and a role that varies by block. Selected by the athlete from options defined by the block's exercise slots.
- **Set** - A value object within a TrainingDay exercise. Contains the prescription (target reps, target RPE, target intensity %) and the actuals (weight used, reps completed, actual RPE). Types of sets:
   - **Work set** - a regular prescribed set (e.g. "4 reps @ RPE 7")
   - **Load drop** - back-off set at reduced weight (e.g. "-5% from top set")
   - **Repeat** - back-off set at the same weight as the top set
   - **Myo-rep set** - activation set followed by short-rest mini-sets (may only appear in later programs)

## RPE Calculator (Domain Service)
The RPE Calculator is a stateless calculation, not an aggregate. It uses:
- An **RPE Percentage Table** (reference data): RPE (6.5-10 in 0.5 increments) x Reps (1-10) = percentage of 1RM. This table is constant across all templates.
- An **RPE Coefficient formula**: `0.0005x² - 0.0342x + 1.025` (used to derive the table values).
- **e1RM calculation**: Takes a known weight at a known reps and RPE, divides by the corresponding percentage to derive e1RM. Uses MAX across multiple inputs if provided. Result rounded to nearest 0.5.
- **Target weight calculation**: `e1RM x rpePercentage(targetReps, targetRPE)` = target weight for a given prescription.

## GPP elements (within Week)
GPP is performed during the week but is flexible on timing. The system recommends when, the athlete can adjust. Four types:
- **Conditioning** - HIIT or LISS cardio. Has duration and intensity (RPE). Block 1 starts with 1x/wk LISS only; later blocks add HIIT and increase frequency.
- **Upper Back Work** - Exercises like pull-ups, rows. Not present in Block 1 week 1.
- **Trunk Work** - Core/ab exercises, often isometric. Not present in Block 1 week 1.
- **Arm Work** - Biceps and triceps, performed as supersets. Not present in Block 1 week 1.

GPP prescriptions come in two flavors:
- **Time-priority** - AMRAP for X minutes (e.g. "7 min AMRAP of Upper Back Work 2x/wk")
- **Task-priority** - X sets of Y reps @ RPE (e.g. "2 sets of 12-20 reps @ RPE 8 2x/wk")

## Needs more discussion
- Where does the AU/CU ratio (acute/chronic workload) live? It's derived from session duration x sRPE across weeks. Is it a read model or part of the Block?
- The Analysis tab auto-populates volume, average intensity, and e1RM trends. This feels like a read model/projection, not an aggregate.
