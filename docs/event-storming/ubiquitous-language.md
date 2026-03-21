# Ubiquitous Language

Glossary. The shared vocabulary of the domain so terms mean the same thing everywhere in code and conversation.

## Confirmed definitions (from Barbell Medicine source material + Excel files)

- **Athlete** (or **Trainee/Lifter**) - A person who trains using the system.
- **Template** - An overall training program (e.g. "Beginner Template"). Contains multiple phases with distinct programming. Each template has a Programming Skeleton that defines all prescriptions.
- **Phase** - A structured training period within a template. Each phase has 4 weeks of unique programming with specific exercise variation, intensity, and volume levels. Week 4 is designed to repeat until progression stalls. Each phase defines its own exercise slots, which increase in complexity across phases.
- **Programming Skeleton** - The master reference data within a template that defines what exercises, prescriptions, and GPP go in each slot for every week of every phase. The weekly tabs and overview are derived from this.
- **Exercise Slot** - A position in a training day that the athlete fills with a specific exercise. Slots are defined by the phase and vary in complexity. Phase 1 has simpler slots (Squat, Vertical Press, Horizontal Press, Deadlift, Row). Phases 2 and 3 have Main/Supplemental/Accessory slots per movement category.
- **Deload Week** - A "low stress" week at the start of Phase 2 and Phase 3 to facilitate recovery from accumulated fatigue of the prior phase. Built into week 1 of the phase's Programming Skeleton.
- **Week** - A 7-day period within a phase, starting on Sunday. Contains training days and GPP elements.
- **Training Day** - A single day's lifting workout within a week. Contains 3 prescribed exercises plus a supplement slot. Performed on non-consecutive days (e.g. M/W/F or T/Th/Sa). Also records session duration and session RPE.
- **Supplement Slot** - An optional 4th slot on each training day. In Phase 1 it's "Conditioning or None." In Phases 2/3 it's "GPP or None." Not a full exercise slot.
- **Exercise** - A specific movement (e.g. "Low Bar Back Squat", "Touch and Go Bench Press", "Paused Deadlift").
- **Movement Category** - A grouping of exercises by movement pattern: Squat, Press, or Deadlift.
- **Exercise Role** - The function an exercise plays in the program. Varies by phase:
  - Phase 1: Squat, Vertical Press, Horizontal Press, Deadlift, Row
  - Phases 2/3: Main Squat, Supplemental Squat, Accessory Squat, Vertical Press, Horizontal Press, Supplemental Press, Main Deadlift, Supplemental Deadlift, Row/Accessory Deadlift
- **Set** - A single bout of an exercise. Logged with weight, reps completed, and RPE (for sets at RPE 6+).
- **Work Set** - A regular prescribed set at a target RPE (e.g. "4 reps @ RPE 8").
- **Back-off Set** - A set performed after the top set at reduced intensity. Two types:
  - **Load Drop** - Reduce weight by a percentage (e.g. "-5% off the bar") and perform sets until reaching the target RPE again.
  - **Repeat** - Stay at the same weight for multiple sets at a target RPE.
- **Fatigue Set** - Another term for back-off sets. The Excel uses "fatigue" and "back off" interchangeably.
- **Myo-Rep** - A specific set protocol: an "activation set" at RPE 8, followed by 5 deep breaths rest, then mini-sets of 3-5 reps until performance drops by 1 rep. Used for hypertrophy work.
- **Prescription** - What the program tells the athlete to do: reps @ RPE with an approximate intensity percentage. Written as "5 reps @ RPE 7 (~81%)". Format varies by phase:
  - Phase 1: simple (e.g. "4 reps @ RPE 6, 4 reps @ RPE 7, 4 reps @ RPE 8")
  - Phase 2: adds back-off sets (e.g. "4 reps @ RPE 9, then -5% for sets until RPE 9")
  - Phase 3: adds singles and more complex structures (e.g. "1 rep @ RPE 8, 5 reps @ RPE 9 x 1 set")
- **RPE** - Rate of Perceived Exertion. A 1-10 scale for how hard a set felt. RPE 7 = 3 reps in reserve, RPE 10 = maximal effort. Recorded in 0.5 increments. RPE takes precedence over percentage targets.
- **RIR** - Repetitions in Reserve. An equivalent way to express RPE. RPE 7 = RIR 3, RPE 9 = RIR 1, RPE 10 = RIR 0.
- **RPE Percentage Table** - A reference lookup table: RPE (6.5-10) x Reps (1-10) = percentage of 1RM. Used by the calculator to convert between e1RM and target weights. This table is constant across all templates.
- **e1RM** - Estimated 1-Rep Max. Derived from training data using the RPE Percentage Table: `e1RM = weight / rpePercentage(reps, rpe)`. The system takes the MAX across all logged inputs and rounds to the nearest 0.5. The primary measure of strength progress.
- **1RM** - One Rep Max. The actual maximum weight lifted for one repetition. Can be tested or estimated.
- **Progressive Overload** - The gradual increase of training stress over time. In this template, primarily achieved by adding 1-5% weight per week without overshooting RPE targets.
- **GPP** - General Physical Preparedness. Supplemental conditioning and accessory work that is not specific to the main lifts but improves overall physical development. Optional in Phase 1, more strongly recommended in later phases.
- **GPP Element** - A specific type of GPP work. Four types: Conditioning, Upper Back Work, Trunk Work, Arm Work.
- **Conditioning** - Cardiovascular training. Uses both LISS (Low Intensity Steady State) and HIIT (High Intensity Interval Training).
- **LISS** - Low Intensity Steady State cardio. e.g. 25-30 minutes on air bike at RPE 6-7.
- **HIIT** - High Intensity Interval Training. e.g. 20-second sprints every 2 minutes on a rower for 12 minutes.
- **Time-priority** - A GPP prescription style: perform AMRAP (as many reps as possible) within a set time. e.g. "7 min AMRAP of Upper Back Work 2x/wk."
- **Task-priority** - A GPP prescription style: perform a specified number of sets and reps. e.g. "2 sets of 12-20 reps @ RPE 8 2x/wk."
- **AMRAP** - As Many Reps As Possible. Used in time-priority GPP prescriptions.
- **Session Duration** - Total time spent training in minutes, including rest periods.
- **Session RPE (sRPE)** - An overall difficulty rating for the entire training session on a 1-10 scale. sRPE 5 = fairly easy, sRPE 8 = difficult but manageable, sRPE 10 = maximal fatigue.
- **AU** - Acute Units. A measure of single-session training stress. Calculated as session duration x sRPE.
- **CU** - Chronic Units. Rolling average of AU over the preceding 4 weeks.
- **AU/CU Ratio** - Compares current week's training stress to the recent average. Used to monitor fatigue and recovery.
- **Tonnage** - Total weight moved, calculated as weight x reps across all sets.
- **Ramp-up** - Weeks 1-3 of a phase, where difficulty gradually increases to the target level.
- **Target Week** - Week 4 of a phase. Represents the full intended workload. Designed to be repeated as long as e1RMs are trending up.

## Terms resolved
- ~~**Phase** vs **Block**~~ - The PDF uses "phase," the Excel files are named "Block I/II/III." Barbell Medicine uses both. **Decision: We use Phase.** "Block" is dropped.
- ~~**GPP sessions**~~ - The correct term is **GPP elements**.
- ~~**Movement Pattern vs Exercise Role**~~ - These are two separate concepts. Movement Category is the pattern (Squat/Press/Deadlift). Exercise Role is the function within the phase (Main/Supplemental/Accessory). The available roles change per phase.
