namespace PleaseBehave
{
    /// <summary>
    /// Implementing IResetable means that the implementer can be reset to a state that is ready
    /// to be called in the node hierarchy.
    /// </summary>
    public interface IResetable
    {
        void Reset();
    }
}