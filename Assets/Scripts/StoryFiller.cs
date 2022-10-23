public static class StoryFiller
{
    private static StoryNode CreateNode(string history, string[] answers)
    {
        var node = new StoryNode
        {
            History = history,
            Answers = answers,
            NextNode = new StoryNode[answers.Length]
        };
        return node;
    }
    public static StoryNode FillStory()
    {
        var node0 = CreateNode(
            "You don't remember what happened, but you are locked in the storage room of some kind of factory. There is a door to the north, a window to the east and a air duct to the west.",
            new[]
            {
                "Try the door",
                "Try the window",
                "Try the air duct"
            });
        var node1 = CreateNode(
            "The door is locked and there is no keyhole. Maybe it's sealed? It won't open.",
            new[]
            {
                "Try the window",
                "Try the air duct"
            });
        var node2 = CreateNode(
            "The window is too high to reach.",
            new[]
            {
                "Try the door",
                "Try the air duct"
            });
        var node3 = CreateNode(
            "You enter the air duct. It's dark, but a light is shining from the north. There's also a humming coming from the south.",
            new[]
            {
                "Go back to the storage room",
                "Go north",
                "Go south"
            });
        var node4 = CreateNode(
            "You go back to the storage room.",
            new[]
            {
                "Try the door",
                "Try the window",
                "Go back into the air duct"
            });
        var node5 = CreateNode(
            "You go north. Congratulations, you're out of the storage room!.",
            new[]
            {
                "End game"
            });
        var node6 = CreateNode(
            "You go south. The humming came from a fan and there's is no way past it, so you turn back. However, when you turn back, you realize that you're stuck. You'll never get out of the air duct.",
            new[]
            {
                "End game"
            });
        node0.NextNode[0] = node1;
        node0.NextNode[1] = node2;
        node0.NextNode[2] = node3;
        node1.NextNode[0] = node2;
        node1.NextNode[1] = node3;
        node2.NextNode[0] = node1;
        node2.NextNode[1] = node3;
        node3.NextNode[0] = node4;
        node3.NextNode[1] = node5;
        node3.NextNode[2] = node6;
        node4.NextNode[0] = node1;
        node4.NextNode[1] = node2;
        node4.NextNode[2] = node3;
        node5.IsFinal = true;
        node6.IsFinal = true;
        return node0;
    }
}
