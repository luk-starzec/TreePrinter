namespace TreePrinter;

internal class InitData
{
    public static List<BlockInfo> GetLogs()
    {
        return new List<BlockInfo>
        {
            new BlockInfo
            {
                ActionName="Start",
            },
            new BlockInfo
            {
                ActionName="A2",
                LoopText="Loop1,0|Loop2,0",
            },
            new BlockInfo
            {
                ActionName="A2.1",
                LoopText="Loop1,0|Loop2,0",
            },
            new BlockInfo
            {
                ActionName="A2",
                LoopText="Loop1,0|Loop2,1",
            },
            new BlockInfo
            {
                ActionName="A2",
                LoopText="Loop1,0|Loop2,2",
            },
            new BlockInfo
            {
                ActionName="A3",
                LoopText="Loop1,0|Loop3,0",
            },
            new BlockInfo
            {
                ActionName="A3",
                LoopText="Loop1,0|Loop3,1",
            },

            new BlockInfo
            {
                ActionName="A2",
                LoopText="Loop1,1|Loop2,0",
            },
            new BlockInfo
            {
                ActionName="A2",
                LoopText="Loop1,1|Loop2,1",
            },
            new BlockInfo
            {
                ActionName="A2",
                LoopText="Loop1,1|Loop2,2",
            },
            new BlockInfo
            {
                ActionName="A3",
                LoopText="Loop1,1|Loop3,0",
            },
            new BlockInfo
            {
                ActionName="A3.1",
                LoopText="Loop1,1|Loop3,0",
            },
            new BlockInfo
            {
                ActionName="A3.2",
                LoopText="Loop1,1|Loop3,0",
            },
            new BlockInfo
            {
                ActionName="A3",
                LoopText="Loop1,1|Loop3,1",
            },
            new BlockInfo
            {
                ActionName="A4",
                LoopText="Loop1,1|Loop3,1|Loop4,0",
            },
            new BlockInfo
            {
                ActionName="A4",
                LoopText="Loop1,1|Loop3,1|Loop4,1",
            },
            new BlockInfo
            {
                ActionName="A3",
                LoopText="Loop1,1|Loop3,2",
            },
            new BlockInfo
            {
                ActionName="Test1",
            },
            new BlockInfo
            {
                ActionName="A5",
                LoopText="Loop5,0",
            },
            new BlockInfo
            {
                ActionName="A5",
                LoopText="Loop5,1",
            },
            new BlockInfo
            {
                ActionName="End",
            },
        };
    }
}
