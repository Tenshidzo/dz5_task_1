using System;

class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Goal(string name, string description)
    {
        Name = name;
        Description = description;
    }
}

class GoalManager
{
    private static Goal[] goals = new Goal[100];
    private static int goalCount = 0;

    public void AddGoal()
    {
        if (goalCount < goals.Length)
        {
            Console.WriteLine("Enter the goal name:");
            string goalName = Console.ReadLine();

            Console.WriteLine("Enter the goal description:");
            string goalDescription = Console.ReadLine();

            goals[goalCount] = new Goal(goalName, goalDescription);
            goalCount++;

            Console.WriteLine($"Goal '{goalName}' added.");
        }
        else
        {
            Console.WriteLine("Maximum number of goals reached.");
        }
    }

    public void ViewGoals()
    {
        Console.WriteLine("List of goals:");

        for (int i = 0; i < goalCount; i++)
        {
            Console.WriteLine($"- {goals[i].Name}: {goals[i].Description}");
        }
    }

    public void CompleteTask()
    {
        ViewGoals();

        Console.WriteLine("Enter the goal number for the completed task:");
        int goalIndex = GetChoice() - 1;

        if (goalIndex >= 0 && goalIndex < goalCount)
        {
            for (int i = goalIndex; i < goalCount - 1; i++)
            {
                goals[i] = goals[i + 1];
            }
            goalCount--;

            Console.WriteLine("Task completed, and goal deleted.");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public static int GetChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Invalid input. Please try again.");
        }
        return choice;
    }
}class Program
{
    static void Main()
    {
        GoalManager goalManager = new GoalManager();

        while (true)
        {
            Console.WriteLine("1. Add a goal");
            Console.WriteLine("2. View goals");
            Console.WriteLine("3. Complete a task");
            Console.WriteLine("4. Exit");

            int choice = GoalManager.GetChoice();

            switch (choice)
            {
                case 1:
                    goalManager.AddGoal();
                    break;
                case 2:
                    goalManager.ViewGoals();
                    break;
                case 3:
                    goalManager.CompleteTask();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }
}

