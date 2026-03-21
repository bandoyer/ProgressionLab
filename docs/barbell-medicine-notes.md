# Barbell Medicine Notes

The project whiteboard. Raw notes on how the Barbell Medicine template works, training structure, progression rules, the real-world domain.

## 3/20/2026
===============================
Initializing a phase/block
===============================
- When the user opens the app, they are presented with a welcome screen where they have to log in or signup
- After logging in, they will be presented with a home page
  - This home page will have a button that says "Select Phase" (block?)
  - Or it will have the option to continue the current phase that was already started
- When a user selects a phase, it will walk them through a series of steps to initialize the phase:
  1. Display a page with an embedded YouTube video to learn more about the program
  2. Have a link to the PDF version of the program to review (this should be easy to view at any time in the app)
  3. Enter Sunday's date for the week you will be starting this phase
  4. The next page will have a list of exercises to choose for this phase
    - There will be three exercise groups they have to select from:
      1. Squat movement
        - Exercise selection:
          - Main Squat
          - Supplemental Squat
          - Accessory Squat
      2. Press movements
        - Exercise selection:
          - Main Press
          - Horizontal Press
          - Supplemental Press
      3. Deadlift movements
        - Exercise selection:
          - Main Deadlift
          - Supplemental Deadlift
          - Accessory Deadlift
    - Each of these exercise groups will have a list of exercises to choose from and embedded YouTube videos to learn more about the exercises
    - This should be one page per exercise group
  5. Once the user has selected all the exercises they want to do, it will initialize the phase/block
- I see that they refer to them as "Beginner Template Block I" and "Beginner Template Block II" and "Beginner Template Block III"
  - I should probably call these templates instead of phases
  - There are multiple templates, and each template may or may not have multiple blocks

================================
Block Setup
================================
- Once the initialization is done, the system will automatically create 16 weeks of workouts
- The first three weeks will gradually increase in difficulty
- The fourth week will be the normal about of work
- The 5th-16th weeks will be identical to the 4th week
- There are formulas for caluclating 1RM, and for setting up the workouts, but that's a different story that's getting in the weeds
- Each week will have three days of workouts AND GPP sessions (https://www.barbellmedicine.com/blog/general-physical-preparedness-gpp-training-for-lifters/_
- There are the following GPP sessions (are these called sessions?)
  1. GPP Cardio (2x/week steady state, 2x/week HIIT, 2000 additional steps per day)
  2. GPP Arm work (2x/week)
  3. GPP Upper back (2x/week)
  4. GPP Ab work (2x/week)
- These will increase in difficulty as the weeks go on from week 1-3, 4 is the normal about of work and week 5-16 will be identical to week 4

- Again, the exercise setup has formulas and RPE calculations that are not important at the moment. 

- *Important:* The automatic 16 weeks are not completely filled out, the user will still have to set weights each week, but it lays
- out the workouts and when each one should be done (in addition to the GPP sessions). The value is just having all of the weeks
- laid out for the user and all they have to do is fill in the weights according to the "Reps & Intensity" section for each workout day.
- For example, on day 1, exercise 1, week 1, the user will have "Low bar back squat" (if they selected that). The Reps & Intensity section will
- guide them on the weights 
  - 1 rep @ RPE 8 (90-92%)
  - 5 reps @ RPE 9 (84%) x 1 set
- 3-5 minutes rest between sets

Feature: There will be a calculator to help them figure out and autofill the weights. Details aren't important at the moment. 