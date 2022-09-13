// Learn more about F# at http://fsharp.org

open System
open System.Linq

let sqr x : float = x * x

let SumSquares nums =
    
    let mutable x = 0.

    for i in nums do
        x <- x + sqr i
    
    x

let rec SumSquares2 nums = 

    match nums with
    | []    -> 0.
    | h::t  -> sqr h + SumSquares2 t


let SumSquares3 nums =
    nums
    |> Seq.map sqr
    |> Seq.sum


let SumSquares4 from tto =
    let list = [from..tto]

    printf "%A" list
    
    List.fold (fun s e -> (s) + (sqr e)) 0. list

let rec sumSquares5 from tto =
    let list = [from..tto]
    SumSquares2 list

let SquareAll list:list<float> =
    let listNew = List.map (fun e -> e * e) list
    listNew

let sumIntegers list : float =
    let num = List.fold (fun s e -> s + e) 0. list 
    num

let rec sumIntegersRec from tto : float = 
    if from > tto then 0.
    else from + sumIntegersRec (from + 1.) tto

let rec sumIntegersRecList list : float =
    match list with
    | [] -> 0.
    | head::tail -> head + sumIntegersRecList tail


//BINARY TREE SEARCH METHODS

type bintree = 
    | MTtree of String
    | Node of compNode
and compNode = {colour: string; left: bintree; right:bintree}


//create binary tree with 1 colour

let rec createBinTree n col =
    if n < 2 then MTtree(col)
    elif n=2 then Node{colour=col; left=MTtree(col); right=MTtree(col)}
    else Node{colour=col; left=createBinTree(n-1)col; right=createBinTree(n-1)col}

//print statement

let rec printDash level: string =
    match level with
    | 0 -> ">"
    | int -> "---" + printDash(level-1)

let rec printBinTree bintree level =
    match bintree with
    | MTtree(str) -> str
    | Node(cNode) -> cNode.colour + " = \n" + printDash level + " Left Child: " + printBinTree cNode.left (level + 1) + "\n" + printDash level + " Right Child: " + printBinTree cNode.right (level + 1) + "\n"


type colBinTree =
    | MTtree of String
    | Node of colCompNode
and colCompNode = {colour: string; left: colBinTree; right: colBinTree}

//create binary tree with 3 colours (determined at levels)

let rec createColBinTree n c1 c2 c3 =
    if n < 2 then MTtree(c3)
    elif n < 4 then Node{colour = c2; left = createColBinTree (n-1) c1 c2 c3; right = createColBinTree (n-1) c1 c2 c3}
    else Node{colour = c1; left = createColBinTree (n-1) c1 c2 c3; right = createColBinTree (n-1) c1 c2 c3} 

let rec printColBinTree colBinTree level =
    match colBinTree with
    | MTtree(str) -> str
    | Node(cNode) -> cNode.colour + " = \n" + printDash level + " Left Child: " + printColBinTree cNode.left (level + 1) + "\n" + printDash level + " Right Child: " + printColBinTree cNode.right (level + 1) + "\n"


//counting colBinTree colours

let intToString int : string =
    string int 

let countNodeColours colList colour =
    let num = List.filter(fun element -> element = colour) colList 
    List.length num 

let rec getNodeColours colBinTree =
    match colBinTree with
    | MTtree(str) -> [str]
    | Node(cNode) -> cNode.colour :: (getNodeColours cNode.left)@(getNodeColours cNode.right)

let printNColours btree = "Nr of red nodes= " + intToString (countNodeColours (getNodeColours btree) "red") + "\n" +
                          "Nr of blue nodes= " +  intToString (countNodeColours (getNodeColours btree) "blue") + "\n"+
                          "Nr of green nodes = " +  intToString (countNodeColours (getNodeColours btree) "green") + "\n"


    

[<EntryPoint>]
let main argv =
    let answer_entry = SumSquares4 0. 3.
    let answer_entry2 = sumSquares5 0. 3.
    let answer = SumSquares2([3.;5.;7.;])
    let answer_entry3 = SquareAll([3. .. 9.])
    let answer_entry4 = sumIntegers([1. .. 9.])
    let answer_entry5 = sumIntegersRec 1. 9.
    //printfn "%f" answer_entry
    //printfn "%f" answer_entry2
    //printfn "%A" answer_entry3
    printfn "%f" answer_entry4
    printfn "%f" answer_entry5

    let FunctionList = [sumIntegers; sumIntegersRecList]

    let x = FunctionList.Item(0) [1. .. 9.]
    printfn "X is equal to %f" x

    let y = FunctionList.Item(1) [1. .. 9.]
    printfn "Y is equal to %f" y

    //bintree stuff
    let binTree1 = createBinTree 3 "green"
    let treeDesc = printBinTree binTree1 1

    printf "\n\n%s" treeDesc

    //colour bintree stuff
    let colBinTree = createColBinTree 4 "red" "blue" "green"
    let treeDesc2 = printColBinTree colBinTree 1

    printf "\n\n%s" treeDesc2
    
    printf "%s" (printNColours colBinTree)

    0 // return an integer exit code
