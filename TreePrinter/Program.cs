using TreePrinter;

int _indent = 0;
var _loopStack = new Stack<LoopInfo>();

var _logs = InitData.GetLogs();

PrintLogs(_logs);


void PrintLogs(List<BlockInfo> logs)
{
    foreach (var log in logs)
    {
        HandleLoops(log);
        HandleBlock(log);
    }
}

void HandleBlock(BlockInfo block)
{
    string txt = MakeIndent(_indent);

    var loopInfo = !string.IsNullOrEmpty(block.LoopText) 
        ? $" ({block.LoopText})" 
        : string.Empty;

    Console.WriteLine($"{txt}Block: {block.ActionName}{loopInfo}");
}

void HandleLoops(BlockInfo block)
{
    var loopsTxt = !string.IsNullOrEmpty(block.LoopText)
        ? block.LoopText.Split('|', StringSplitOptions.RemoveEmptyEntries)
        : Array.Empty<string>();

    var loops = new List<LoopInfo>();
    foreach (var l in loopsTxt)
    {
        loops.Add(GetLoopInfoFromText(l));
    }

    while (_loopStack.Any())
    {
        var lastOnStack = _loopStack.Peek();

        var blockContainsLastOnStack = loops
            .Where(r => r.Name == lastOnStack.Name)
            .Where(r => r.Iteration == lastOnStack.Iteration || lastOnStack.Iteration < 0)
            .Any();
        if (blockContainsLastOnStack)
        {
            break;
        }

        var blockContainsLastOnStackIteration = loops
            .Where(r => r.Name == lastOnStack.Name)
            .Where(r => r.Iteration == lastOnStack.Iteration)
            .Any();
        if (!blockContainsLastOnStackIteration)
        {
            _indent = EndIteration(_indent);
            _loopStack.Pop();
            _loopStack.Push(new LoopInfo
            {
                Name = lastOnStack.Name,
                Iteration = -1, // active loop without active iteration
            });
        }
        var blockContainsLastOnStackName = loops
            .Where(r => r.Name == lastOnStack.Name)
            .Any();
        if (!blockContainsLastOnStackName)
        {
            _indent = EndLoop(_indent);
            _loopStack.Pop();
        }
    }

    foreach (var loop in loops)
    {
        var containsLoop = _loopStack
            .Where(r => r.Name == loop.Name)
            .Any();
        var containsIteration = _loopStack
            .Where(r => r.Name == loop.Name)
            .Where(r => r.Iteration == loop.Iteration)
            .Any();

        var beginLoop = !containsLoop;
        var beginIteration = !containsLoop || !containsIteration;

        if (!beginLoop && !beginIteration)
        {
            continue;
        }

        if (beginLoop)
        {
            _indent = BeginLoop(loop.Name, _indent);
        }
        _indent = BeginIteration(loop.Name, loop.Iteration, _indent);

        var lastOnStack = _loopStack.Any() ? _loopStack.Peek() : null;
        if (lastOnStack?.Iteration < 0)
        {
            _loopStack.Pop();
        }

        _loopStack.Push(new LoopInfo
        {
            Name = loop.Name,
            Iteration = loop.Iteration,
        });
    }
}

int BeginLoop(string loopName, int indent)
{
    var result = indent;
    var txt = MakeIndent(_indent);

    Console.WriteLine($"{txt}{loopName}");
    return result + 1;
}

int EndLoop(int indent)
{
    return indent - 1;
}

int BeginIteration(string loopName, int iteration, int indent)
{
    var result = indent;
    var txt = MakeIndent(_indent);

    Console.WriteLine($"{txt}{loopName} #{iteration}");
    return result + 1;
}

int EndIteration(int indent)
{
    return indent - 1;
}

LoopInfo GetLoopInfoFromText(string text)
{
    var items = text.Split(',', StringSplitOptions.RemoveEmptyEntries);
    return new LoopInfo
    {
        Name = items[0],
        Iteration = int.Parse(items[1]),
    };
}

string MakeIndent(int indent)
{
    var txt = "";
    for (int i = 0; i < indent; i++)
        txt += ".";
    return txt;
}
