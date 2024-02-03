# Navigating the Code Clouds: Advanced Features of GitHub Copilot 
This lab exercise covers ... // TODO: Add summary here

## Prerequisites
- The prerequisites steps are completed, see [Labs Prerequisites](https://github.com/XpiritBV/Copilot-Bootcamp#labs-prerequisites)

## Estimated time to complete
- 30 min

## Objectives
- Exploring advanced features and capabilities of GitHub Copilot.
- Participants tackle more complex coding exercises with Copilot, focusing on AI's role in problem-solving and code optimization.

### Required

### Lab 4.1 - The Complete Wright Brothers Fleet

- Open the `Plane.cs` file.

- Add a `ImageUrl` property to the model.

- Type 'public string ImageUrl { get; set; }' in the `Plane.cs` file.

```csharp
public class Plane
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public int RangeInKm { get; set; }

    // New property
    public string ImageUrl { get; set; }
}
```

- Open the `PlanesController.cs` file.

- Select all content of the `Planes` List.

- Right click and choose for the option `Copilot` -> `Inline Chat`.

- Type the following command

```
Add the new ImageUrl property and complete the Wright Brothers Fleet
```

TODO: Add a Screenshot here! - Select List and do inline chat and type in the command
![Image of TBD](/Images/placeholder-Small.png)

- Accept the suggestion by selecting `Accept` or pressing `Enter`.

> [!Note]
> Copilot just demonstrated that it can do more than one thing at a time. It added the new property and filled in the list of planes.

### Lab 4.2 - Flight Logbook - Logging Your Coding Journey

- Open the `PlanesController.cs` file.

- Select all content of the `PlanesController.cs` file.

- Right click and choose for the option `Copilot` -> `Generate Docs`.

TODO:  [Screenshot] - Select all - Right click - Generate Docs
![Image of TBD](/Images/placeholder-Small.png)

- Accept the suggestion by selecting `Accept`.

TODO:  [Screenshot] - Accept
![Image of TBD](/Images/placeholder-Small.png)

> [!Note]
> GitHub Copilot used the `/docs` agent to generate the documentation for the entire file in a matter of seconds.

### Lab 4.3 - Flying in Formation - Pair Programming with Copilot

- Open the `FlightsController.cs` file.

- Navigate to the `UpdateFlightStatus` method.

> [!Note]
> Note that the `UpdateFlightStatus` method has a high code complexity rating.

- Select all the content of the `UpdateFlightStatus` method.

- Open the Copilot Chat extension.

- Ask the following question:

```
Refactor the selected code to make it more readable and maintainable.
```

> [!Note]
> GitHub Copilot Chat understands `the selected code`. It will use the selected code in your editor to generate the refactoring suggestions.

> [!Note]
> To make it more readable and maintainable, Copilot will suggest to extract the code into a separate method, appying the Single Responsibility Principle of the SOLID principles.

> [!Note]
> Note that GitHub Copilot Chat can make mistakes sometimes. Best practice is to have the method covered with unit tests before refactoring it. This is not a requirement for this lab, but it is a good practice to follow. These unit tests can be generated by GitHub Copilot as well, which is covered in a previous lab.

## Optional

### Lab 4.4 - Parsing Flight Show - String parsing

- Open the `FlightController.cs` file.

- Go to the List of Flights:

```csharp
public class FlightsController : ControllerBase
{
    private List<Flight> Flights = new List<Flight>
    {
        new Flight
        {
            // Other Properties
            // ...
            // Format: DDMMYY-DEP-ARR-FLIGHT
            // For this flight
            // 17th of December 1903
            // Departure from Kitty Hawk, NC
            // Arrival at Manteo, NC
            // Flight number WB001
            FlightLogSignature = "171203-DEP-ARR-WB001"

        },
        // Second flight
    };
}


```

> [!Note]
> Note that the `FlightLogSignature` is a fictional property that is used to demonstrate the capabilities of GitHub Copilot. It is not a real aviation concept.

- Select all the content of the `FlightLogSignature` property and its description.

- Open the Copilot Chat extension and ask the following question:

```
How to parse the selected FlightLogSignature string into a c# model
```
- Copilot will suggest `FlightLogSignature` class and a `Parse` method:

```csharp
public class FlightLogSignature
{
    public DateTime Date { get; set; }
    public string Departure { get; set; }
    public string Arrival { get; set; }
    public string FlightNumber { get; set; }
}
```

```csharp
public static FlightLogSignature Parse(string flightLogSignature)
{
    // method body
}
```

> [!Note]
> GitHub Copilot is very good at understanding the context of the code. It understands that the `FlightLogSignature` is a string in a specific format and that it can be parsed into a `FlightLogSignature` model, to make the code more readable and maintainable.


- Now add the suggested `Parse` method to the `FlightsController.cs` class. 

- Open `FlightsController.cs` file.

- Place your cursor at the end of the file, after the `}` of the `UpdateFlightStatus` method.

TODO: Add a Screenshot here! - Insert code at cursor
![Image of TBD](/Images/placeholder-Small.png)

> [!Note]
> GitHub Copilot has many quick actions that can be used to speed up the development process. In this case, it pasted the suggested code on the cursor in the editor. 

- Now add the suggested `FlightLogSignature` model to the codebase. In the Copilot Chat extension window, press the button to create a new file based on the suggestion.

```csharp
public class FlightsController : ControllerBase
{
    /* Rest of the methods */

    [HttpPut("{id}")]
    public ActionResult<Flight> UpdateFlightStatus(int id, Flight flight)
    {
        // method body
    }

    <---- Place your cursor here
}
```

TODO: Add a Screenshot here! - Create new file in the Copilot Chat extension
![Image of TBD](/Images/placeholder-Small.png)

- In the Copilot Chat extension window, press the button to add the method to the `FlightsController.cs` class.

[Screenshot] - Add method to the `FlightsController.cs` class in the Copilot Chat extension.
![Image of TBD](/Images/placeholder-Small.png)


> [!Note]
> GitHub Copilot has many quick actions that can be used to speed up the development process. In this case, it added the `Parse` method to the `FlightsController.cs` class.


#### Lab 4.5 - Regex Aerobatics Show - Regular Expressions

- Open the `Flight.cs` file.

- Start by adding the `AerobaticSequence` property to the `Flight.cs` file.

```csharp
public class Flight
{
    
    // Other properties
    //
    // ...
    // 
    // Encodes a series of aerobatic maneuvers
    // L = Loop, H = Hammerhead, R = Roll, S = Spin, T = Tailslide
    // Number represents repeat count, 
    // Letter represents difficulty (A-E)
    // Example 1: L4B-H2C-R3A-S1D-T2E
    // Example 2: L1A-H1B-R1C-S1D-T1E
    public string AerobaticSequence { get; set; }
}
```

> [!Note]
> Note that the `AerobaticSequence` is a fictional property that is used to demonstrate the capabilities of GitHub Copilot. It is not a real aviation concept.

- Open the `Flight.cs` file.

- Select all the content of the `AerobaticSequence` property and its description.

- Open the Copilot Chat extension and ask the following question:

```
How to parse the selected AerobaticSequence string into a c# model using a regex expression
```

- Copilot will suggest `AerobaticSequence` class and a `Parse` method.

> [!Note]
> GitHub Copilot is very good at understanding the context of the code. It understands that the `AerobaticSequence` is a string in a specific format and that it can be parsed using a Regex expression.

#### Lab 4.6 - Flight Plan Adjustments - Codebase Improvements

TODO: Maybe Remove this???

- Engage in a chat with Copilot to discuss potential improvements in the codebase or selected sections of code.
- Introduce a context file to instruct Copilot on what to do and not to do, possibly aligning with company guidelines.
- Gradually apply Copilot's suggestions to the code. Consider using a .copilotignore file to refine Copilot's focus.
- Keep code quality reference files open for guidance and comparison.