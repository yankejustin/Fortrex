namespace prjFortrex.GameEngine.Network
{
    /// <summary>
    /// The type of action that is to be performed.
    /// </summary>
    public enum Command : int
    {
        /// <summary>
        /// No action.
        /// </summary>
        None = 0,
        /// <summary>
        /// Move an object on the game form.
        /// </summary>
        Move = 1,
        /// <summary>
        /// Sending or receiving a message.
        /// </summary>
        MessageSend = 2,
        /// <summary>
        /// Kick/Remove a player from the server.
        /// </summary>
        Kick = 3,
        /// <summary>
        /// Ban a player from the server.
        /// </summary>
        Ban = 4
    }
}