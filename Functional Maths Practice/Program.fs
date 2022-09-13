// Learn more about F# at http://fsharp.org

open System

//original code
let IsPrimeMultipleTest n x =
   x = n || x % n <> 0

let rec RemoveAllMultiples listn listx =
   match listn with
   | head :: tail -> RemoveAllMultiples tail (List.filter (IsPrimeMultipleTest head) listx) // List.filter predicate list
   | [] -> listx

let GetPrimesUpTo n =
    let max = int (sqrt (float n))  // typecast to int32
    RemoveAllMultiples [ 2 .. max ] [ 2 .. n ]

let rec printList list = 
    match list with
    | head::tail -> sprintf "%d " head + (printList tail)
    | [] -> "\n"




(*
improved code for task 
- IsPrimeMultipleTest n x is replaced with a lambda expression: (fun x -> x = n || x % num <> 0) listx
*)

let rec RemoveAllMultiples2 (max:int) (index:int) (listx:List<int>) =
    let num = listx.Item(index)
    if num <= max then RemoveAllMultiples2 max (index + 1) (List.filter (fun x -> x % num <> 0) listx)
    else
        listx 


(*
The helper list is removed and instead the last found prime number is simply selected as the 'next' element using an
idex that starts at position 0 (first element, which is two, the only even prime number).

This means that the new version of RemoveAllMultiples has now two int parameters, i.e. the max number to test multiplicity
and the original list of all the number from 2 to n; which is gradually updated as multiples of a found prime number are
removed via removeAllMultiples2

*)

let GetPrimeUpTo2 n =
    let max = int (sqrt (float n)) //typecast to int for type safety
    RemoveAllMultiples2 max 0 [2 .. n]



[<EntryPoint>]
let main argv =
    let list1 = GetPrimesUpTo 100
    let output = printList list1
    Console.WriteLine("Output = {0}",output)
    let list2 = GetPrimesUpTo 100
    let output = printList list2
    Console.WriteLine("Output = {0}",output)

    if list1.Equals(list2) then 
        printf("hello")

    0 // return an integer exit code