module m2048 

type pos = int*int // A 2-dimensional vector in board-coordinates (not pixels)
type value = Red | Green | Blue | Yellow | Black // Piece values
type piece = value*pos //
type state = piece list // The board is a set of randomly organised pieces 

/// <summary> Turns a color value into a Canvas.color. </summary>
/// <param name="v"> A color value </param> 
/// <returns> A Canvas color value. </returns>
val fromValue : value -> Canvas.color 

/// <summary> Turns a color into the new color when merging pieces. </summary>
/// <param name="c"> The color value. </param> 
/// <returns> A new Canvas color value. </returns>
val nextColor : value -> value 

/// <summary> Filters a piece list according to column. </summary>
/// <param name="k"> The column number. </param> 
/// <param name="s"> A state. </param>
/// <returns> A piece list with only the pieces in the given column number </returns>
val filter : int -> state -> state 

/// <summary> Sorts a piece list according to row (x coordinate). </summary>
/// <param name="s"> A board state. </param>
/// <returns> A board state with pieces sorted by row </returns>
let sortRow : state -> state 

/// <summary> Matches a piece list with a pattern and moves the pieces. </summary> 
/// <param name="s"> A state. </param>
/// <returns> A piece list sorted according to column and row with appropriate
/// pieces merged. </returns>
val shiftUp : state -> state 

/// <summary> Flip the board s such that all pieces' position change as 
/// (i,j) -> (2-i,j). </summary> 
/// <param name="s"> A board state. </param>
/// <returns> A state with all the pieces x coordinates changed. </returns> 
val flipUp : state -> state 

/// <summary> Flip the board s such that all pieces' position change as 
/// (i,j) -> (2-i,j). </summary> 
/// <param name="s"> A board state. </param>
/// <returns> A state with all the pieces x coordinates changed. </returns>
val transpose : state -> state 

/// <summary> Find the list of empty positions on the board. </summary> 
/// <param name="s"> A board state. </param>
/// <returns> A list with the empty positions. </returns>
val empty : state -> pos list 

/// <summary> Adds a random red piece to the board on an empty position. </summary> 
/// <param name="c"> Color value. </param>
/// <param name="s"> Board state. </param>
/// <returns> The state list with a random piece added. </returns>
val addRandom : value -> state -> state option 

/// <summary> Draws the canvas and pieces. </summary> 
/// <param name="w"> Width of the canvas. </param>
/// <param name="h"> Height of the canvas. </param>
/// <param name="s"> The board state. </param>
/// <returns> The canvas with all pieces drawn. </returns>
val draw : int -> int -> state -> canvas 

/// <summary> Changes the board according to arrow keys. </summary> 
/// <param name="s"> The board state. </param>
/// <param name="k"> The input arrow key. </param>
/// <returns> The re-arranged board. </returns>
val react : state -> key -> state option 




    