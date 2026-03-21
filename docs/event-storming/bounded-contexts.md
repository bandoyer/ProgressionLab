# Bounded Contexts

Pink stickies. Context boundaries where language or rules change.

## Emerging contexts

1. **Identity** - Signup, login, athlete account. "Athlete" here means credentials and profile.
2. **Programming** - Templates, phases, exercise selection, week generation, rep and intensity prescriptions, the RPE calculator, target weight generation. "Athlete" here means someone configuring their training plan. The calculator lives here since it's used before the workout starts.
3. **Training** - The actual day-to-day logging of sets (weight, reps, RPE), completing training days (session duration, sRPE), tracking GPP elements. "Athlete" here means someone in the gym doing the work. e1RM auto-calculation happens here based on logged data.
4. **Analysis** - e1RM trends over time, AU/CU ratio tracking, weekly volume and average intensity summaries. "Athlete" here means someone reviewing their progress to make decisions.

## Needs more discussion
- Does GPP belong in Training or is it its own context? It has different prescription styles (time-priority vs task-priority) and is more flexible than the lifting days. But it's still tracked the same way.
- The word "Athlete" means something slightly different in each context. That's a classic sign of separate bounded contexts.
- Analysis might be a read model/projection rather than a full bounded context. It derives everything from Training data. Worth deciding if it has its own domain logic or is purely a view.
- Is Progression (deciding when to advance phases) part of Programming, Analysis, or its own thing? The rule "advance when 2+ e1RMs stall" sits between analysis of data and a programming decision.
