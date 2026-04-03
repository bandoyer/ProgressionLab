# Ubiquitous Language

Glossary. The shared vocabulary of the domain so terms mean the same thing everywhere in code and conversation.

## Confirmed definitions (from Barbell Medicine source material + Excel files)

- **Athlete** (or **Trainee/Lifter**) - A person who trains using the system.
- **Program** - An overall training program (e.g. "Beginner Template", "Strength I"). Lifters and coaches refer to these as "programs" or "programming." The aggregate root — always created and modified as a whole. Contains one or more Blocks. Barbell Medicine calls their products "templates" but the domain concept is a program.
- **Block** - A structured training period within a Program (e.g. Block I, Block II). Each block has distinct goals, exercise variation, intensity, and volume levels. Some weeks are designed to repeat until progression stalls. Each block defines its own exercise slots, which can change across blocks.
- **Slot** - A numbered, exercise-agnostic position within a Week. The Program defines what prescription each slot gets. Exercise Selection (separate concern) assigns a specific movement to each slot. This separation allows the same prescription structure to work across different exercise choices. Slot labels vary by program (e.g. Beginner uses generic numbering, Strength I labels by muscle group: Quad 1, Chest I, etc.).
- **Deload Week** - A "low stress" week at the start of a block to facilitate recovery from accumulated fatigue of the prior block.
- **Week** - A 7-day period within a block, starting on Sunday. Contains training days and GPP elements.
- **Training Day** - A single day's lifting workout within a week. Contains 3 prescribed exercises plus a supplement slot. Performed on non-consecutive days (e.g. M/W/F or T/Th/Sa). Also records session duration and session RPE.
- **Supplement Slot** - An optional 4th slot on each training day. May be "Conditioning or None" or "GPP or None" depending on the block. Not a full exercise slot.
- **Exercise** - A specific movement (e.g. "Low Bar Back Squat", "Touch and Go Bench Press", "Paused Deadlift").
- **Movement Category** - A grouping of exercises by movement pattern: Squat, Press, or Deadlift.
- **Exercise Role** - The function an exercise plays in the program. Varies by block (e.g. simpler roles in early blocks, Main/Supplemental/Accessory distinctions in later blocks).
- **Set** - A single bout of an exercise. Logged with weight, reps completed, and RPE (for sets at RPE 6+).
- **Work Set** - A regular prescribed set at a target RPE (e.g. "4 reps @ RPE 8").
- **Back-off Set** - A set performed after the top set at reduced intensity. Two types:
  - **Load Drop** - Reduce weight by a percentage (e.g. "-5% off the bar") and perform sets until reaching the target RPE again.
  - **Repeat** - Stay at the same weight for multiple sets at a target RPE.
- **Fatigue Set** - Another term for back-off sets. The Excel uses "fatigue" and "back off" interchangeably.
- **Myo-Rep** - A specific set protocol: an "activation set" at RPE 8, followed by 5 deep breaths rest, then mini-sets of 3-5 reps until performance drops by 1 rep. Used for hypertrophy work.
- **Prescription** - What the program tells the athlete to do: reps @ RPE with an approximate intensity percentage. Written as "5 reps @ RPE 7 (~81%)". Format varies by block complexity — from simple ramping sets to back-off sets, singles, and double progression.
- **RPE** - Rate of Perceived Exertion. A 1-10 scale for how hard a set felt. RPE 7 = 3 reps in reserve, RPE 10 = maximal effort. Recorded in 0.5 increments. RPE takes precedence over percentage targets.
- **RIR** - Repetitions in Reserve. An equivalent way to express RPE. RPE 7 = RIR 3, RPE 9 = RIR 1, RPE 10 = RIR 0.
- **RPE Percentage Table** - A reference lookup table: RPE (6.5-10) x Reps (1-10) = percentage of 1RM. Used by the calculator to convert between e1RM and target weights. This table is constant across all programs.
- **e1RM** - Estimated 1-Rep Max. Derived from training data using the RPE Percentage Table: `e1RM = weight / rpePercentage(reps, rpe)`. The system takes the MAX across all logged inputs and rounds to the nearest 0.5. The primary measure of strength progress.
- **1RM** - One Rep Max. The actual maximum weight lifted for one repetition. Can be tested or estimated.
- **Progressive Overload** - The gradual increase of training stress over time. Primarily achieved by adding 1-5% weight per week without overshooting RPE targets.
- **GPP** - General Physical Preparedness. Supplemental conditioning and accessory work that is not specific to the main lifts but improves overall physical development. May be optional in early blocks, more strongly recommended in later blocks.
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
- **Ramp-up** - Early weeks of a block, where difficulty gradually increases to the target level.
- **Target Week** - The final programmed week of a block. Represents the full intended workload. Designed to be repeated as long as e1RMs are trending up.
- **Ramping Sets** - A warm-up strategy where the lifter performs sets of successively heavier weight (e.g. 4 reps @ RPE 6, 4 reps @ RPE 7, 4 reps @ RPE 8) to arrive at the working weight.
- **Double Progression** - A progression strategy where the lifter maxes out the rep range at a given weight before increasing load. Used for supplemental/accessory exercises (e.g. "6-10 reps @ RPE 7, repeat weight x 2 sets").
- **WATER** - The exercise prescription variables: Weight (intensity), Amount (volume), Type (mode), Effort, and Regulation. Barbell Medicine's framework for programming decisions.

## Terms resolved
- ~~**Template** vs **Program**~~ - Barbell Medicine calls their products "templates" but lifters and coaches universally say "programs" and "programming." **Decision: We use Program.** "Template" is dropped from domain language (kept only as a Barbell Medicine product name).
- ~~**Phase** vs **Block**~~ - The 1st gen PDF uses "phase," the 2nd gen has fully committed to "Block." **Decision: We use Block.** "Phase" is dropped.
- ~~**Programming Skeleton**~~ - The spreadsheet tab name. Not its own concept — it's the *relationship* between Program → Blocks → Weeks → Slots → Prescriptions viewed as a whole. Not modeled as a separate object.
- ~~**GPP sessions**~~ - The correct term is **GPP elements**.
- ~~**Movement Pattern vs Exercise Role**~~ - These are two separate concepts. Movement Category is the pattern (Squat/Press/Deadlift). Exercise Role is the function within the block (Main/Supplemental/Accessory). The available roles change per block.
