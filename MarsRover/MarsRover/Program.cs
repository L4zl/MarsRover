using MarsRover;

//Create new Movement service
var service = new MovementService();

//empty input
List<string> input = new List<string>();

Console.WriteLine("Enter Grid Size in form: x y. i.e. 1 2");

input.Add(Console.ReadLine());

bool read = true;

Console.WriteLine("Enter Robot Starting position and commands. i.e. (2, 3, E) LFRFF");

while (read)
{
    var inputLine = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(inputLine))
        read = false;
    else
        input.Add(inputLine);
}

var output = service.Run(input);

//Print each output
foreach(string s in output)
{
    Console.WriteLine(s);
}