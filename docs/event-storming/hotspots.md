# Hotspots

Red stickies. Questions, conflicts, and unknowns that need to be resolved.

## Language hotspots (RESOLVED)
1. ~~**Phase vs Block vs Template**~~ **RESOLVED**: The PDF uses "phase" in the body text. The Excel files are named "Block I, Block II, Block III." Barbell Medicine uses both terms interchangeably. **Decision: We use Phase.** A Template contains Phases. "Block" is dropped from our ubiquitous language.
2. ~~**GPP "sessions"**~~ **RESOLVED**: Barbell Medicine calls them **GPP elements**. Four types: Conditioning, Upper Back Work, Trunk Work, Arm Work. Two prescription styles: Time-priority (AMRAP) and Task-priority (sets x reps @ RPE).
3. ~~**Movement Pattern vs Exercise Role**~~ **RESOLVED from Excel**: The exercise slots change per phase. Phase 1 has simpler slots (Squat, Vertical Press, Horizontal Press, Deadlift, Row). Phases 2 and 3 introduce Main/Supplemental/Accessory distinctions. Movement Category and Exercise Role are two separate concepts. A movement category (Squat) can have multiple roles (Main Squat, Supplemental Squat, Accessory Squat) depending on the phase.

## Language hotspots (OPEN)
4. **"Supplement" slot** - Each training day has Exercise 1, Exercise 2, Exercise 3, and a "Supplement" column. The Excel shows this as "GPP or None" in Phases 2/3 and "Conditioning or None" in Phase 1. It appears to be an optional GPP attachment to a training day, not a 4th exercise.
5. **Load Drop vs Repeat** - Back-off sets come in two flavors. A "load drop" reduces weight after the top set (e.g. "-5% from top set"). A "repeat" keeps the same weight for multiple sets. Are these distinct domain concepts or just variants of a back-off set?
6. **Day 4** - The Excel Overview shows 4 days per week, but Day 4 references "Slot 10/11/12" which appear to be placeholder or configurable slots. The PDF says "three days of strength training." Is Day 4 a real training day or an optional/template-specific slot?
7. **Myo-Reps** - The TABLES help text describes a specific set protocol: an "activation set" at RPE 8 followed by short-rest mini-sets of 3-5 reps until performance drops. This is a distinct prescription style beyond regular sets and back-off sets. Does this appear in the Beginner Template or only in later templates?

## Design hotspots (RESOLVED from Dan's answers + PDF + Excel)
8. ~~**Prescription vs Actuals**~~ **RESOLVED**: Each set has a prescription (target reps, target RPE, approximate intensity %) and actuals (weight used, reps completed, actual RPE). RPE takes precedence over percentages.
9. ~~**1RM source**~~ **RESOLVED from Excel**: The calculator has three input rows (Known @ 10 RPE, Known @ 9 RPE, Known @ 8 RPE) across 1-10 reps. It divides each known value by the corresponding percentage from the RPE table and takes the MAX to derive e1RM. The formula is: `e1RM = MAX(knownWeight / rpePercentage)` across all inputs. The result is rounded to the nearest 0.5. You can enter any known effort at any rep count and RPE to bootstrap.
10. ~~**GPP tracking**~~ **RESOLVED**: Tracked similarly to lifting but simpler. Time-priority GPP is AMRAP-based with a timer. Task-priority GPP is sets x reps @ RPE.
11. ~~**RPE Calculator mechanics**~~ **RESOLVED from Excel**: The calculator uses a lookup table of RPE (6.5-10 in 0.5 increments) x Reps (1-10) = percentage of 1RM. Target weight = e1RM x percentage. There are also RPE coefficients for the underlying formula: `0.0005x² - 0.0342x + 1.025`. The full RPE percentage table is reference data that can be hardcoded.

## Design hotspots (OPEN)
12. **Exercise slots vary by phase** - Phase 1 has fewer, simpler exercise slots. Phases 2 and 3 have more slots with Main/Supplemental/Accessory distinctions. This means the exercise selection step is phase-specific. The Template needs to define which exercise slots each phase offers.
13. **Programming Skeleton** - The Excel has a hidden "PROGRAMMING SKELETON" sheet that the Overview and Weekly tabs reference via OFFSET formulas. This is the master definition of what exercises go where and what the prescriptions are for each week. This is the template's programming logic. It's reference data that drives everything.
14. **Phase generation is really template lookup** - The system doesn't "generate" weeks with complex logic. It reads the prescriptions from the Programming Skeleton (reference data) and creates weeks with those prescriptions plus the athlete's exercise selections. The ramp-up is baked into the skeleton, not calculated.
15. **Week repetition mechanics** - When week 4 repeats, what actually happens in the system? Is a new Week entity created as a copy? The tab names (4.2, 4.3, 4.4...) are a spreadsheet concern, but the domain needs to track which repetition the athlete is on.
16. **Phase transition and deload** - Phases 2 and 3 start with a "deload" or "low stress" week. Is this a special Week type? The Excel suggests Week 1 of each phase IS the deload (for Phases 2/3). It's built into the Programming Skeleton, not a separate concept.
17. **AU/CU ratio** - Acute Units = session duration x sRPE. Chronic Units = rolling average of AU over 4 weeks. Where does this calculation live? Is it a domain concern or purely analytical?
18. **Progression decision ownership** - The rule is "advance when 2+ e1RMs stall or regress." The system can detect this from the Analysis data. Dan said the athlete can repeat as long as they want and add weeks. So it's a recommendation, not enforcement.
19. **Phase-specific programming complexity** - Phase 1 prescriptions are simple: "4 reps @ RPE 6, 4 reps @ RPE 7, 4 reps @ RPE 8." Phase 3 introduces single-rep work and back-off sets: "1 rep @ RPE 8, 5 reps @ 9 x 1 set." The prescription format is not uniform across phases. How do we model this?
