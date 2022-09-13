
open System

let hello() = 
   printf "Please Enter Your Name:   "
   let name = Console.ReadLine()
   printfn "Hello %s" name

let bind_stuff() =
   let mutable weight = 175
   weight <- 170

   printfn "Weight : %i" weight

   let change_me = ref 10
   change_me := 50

   printfn "Weight : %i" ! change_me //exclamation point used to present a referenced variable (mutabke)

let do_funcs() =
   
   let get_sum (x : int, y : int) : int = x + y  //defined arguments and gave optional type safety & defined func body

   printfn "5 + 7 = %i" (get_sum(5,7))

//recursive functions
let do_funcs2() = 

    let rec factorial x = //have to define it is recursive with key word "rec"
        if x < 1 then 1
        else x * factorial (x - 1) //calling function again if x is not less than 1

    printf "factorial of 4 is : %i" (factorial 4)

//using lambda expressions
let do_funcs3() = 

    let rand_list = [1;2;3;]
    
    let rand_list2 = List.map (fun x -> x * 2) rand_list

    printf "Double List : %A" rand_list2

    [5;6;7;8;] //piplining! dont have define and reference this as a variable
    |> List.filter (fun v -> (v % 2) = 0) //filter runs list through condition and only pipes items that match condition
    |> List.map (fun x -> x * 2)
    |> printfn "Even Doubles : %A"

    let mult_num x = x * 3
    let add_num y = y + 5
    
    let mult_add = mult_num >> add_num
    let add_mult = mult_num << add_num


    printfn "mult_add : %i" (mult_add 10)
    printfn "add_mult : %i" (add_mult 10)



let string_stuff() = 
    let str1 = "hello"

    printfn "Length = %i" (String.length str1)
    printfn "Character at position 1 is : %c" str1.[1]
    printfn "Range of chars 1st 4 letters of hello : %s" (str1.[0..3])

    let upperCase = String.collect (fun c -> sprintf"%c, " c) "commas"
    printfn "Commas : %s" upperCase

    printfn "Boolean check if any char is uppercase : %b" (String.exists (fun c -> Char.IsUpper(c)) str1)

    printfn "Does this string contain all numbers? : %b" (String.forall (fun c -> Char.IsDigit(c)) "1234")

    let string1 = String.init 10 (fun i -> i.ToString())
    printfn "Numbers : %s" string1

    String.iter(fun c -> printfn "%c" c) "print me"

//magic number guessing game!

let loop_stuff() =
    let magic_number = "7"
    let mutable guess = ""
    
    while not (magic_number.Equals(guess)) do
        printf "Guess The Number! : "
        guess <- Console.ReadLine()
    
    printf "you guessed the number!"

let loop_stuff2() = 
    for i = 1 to 10 do
        printfn "i is equal to %i" i
    
    for i = 10 downto 1 do
        printfn "i is equal to %i" i

    for i in [1..10] do
        printfn "i is equal to %i" i
    
    [1..10] |> List.iter (printfn "Num : %i")

    let sum = List.reduce (+) [1..10] 
    printfn "sum = %i" sum 

//conditional stuff

let cond_stuff() = 
    let age = 8

    if age < 5 then
        printfn "preschool"
    elif age = 5 then
        printfn "Kindergarten"
    elif (age > 5) && (age <= 18) then
        let grade = age - 5
        printfn "Go to grade %i" grade
    else
        printfn "Go to College!"
    
    //or operator

    let grades = 3.9
    let income = 15000

    printfn "whoops, College Grant : %b" ((grades >= 3.8) || (income <= 12000))

    //not symbol

    printfn "Not true : %b" (not true)

    //match and guard statement to do the same thing

    let grade2: string =
        match age with 
        | age when age < 5 -> "Preschool"
        | 5 -> "Kindergarten"
        | age when ((age > 5) && (age <= 18)) -> (age - 5).ToString()
       
    printfn "Grade 2: %s" grade2



//list operators and revision

let list_stuff() =
    let list1 = [1;2;3;4;]

    list1 |> List.iter (printfn "Num : %i")

    printfn "%A" list1

    let list2 = 5::6::7::[]
    printfn "%A" list2

    let list3 = [1..5]
    let list4 = ['a'..'g']
   
    let nestedList = [list1; list2; list3;]

    nestedList |> List.iter (printfn "%A")

    //generating a list via init

    let list5 = List.init 5 (fun i -> i * 2)
    printfn "List 5 : %A" list5

    //generating list using yield

    let list6 = [for a in [1..5] do yield (a * a)]

    let list7 = [for a in [1..20] do if a % 2 = 0 then yield a]

    //using yield bang to create multiple lists for each item then merge

    let list8 = [for a in [1..3] do yield! [a .. a + 2]]

    printfn "List 6: %A" list6
    printfn "List 7: %A" list7
    printfn "List 8: %A" list8

    //getting length of list

    printfn "Length : %i" list8.Length
    printfn "Is empty : %b" list8.IsEmpty
    printfn "Index 2 : %c" (list4.Item(2))
    printfn "Head : %c" (list4.Head)
    printfn "Tail : %A" (list4.Tail) //tail is everything except for first item

    let list9 = list3 |> List.filter(fun x -> x % 2 = 0) 
    
    let list10 = list9 |> List.map (fun x -> (x*x))

    printfn "Sorted List : %A" (List.sort [5;6;1;3;2;10;6;])

    printfn "Sum %i" (List.fold (fun sum elem -> sum + elem) 0 list10)

//enum stuff, allows us to use specific info and assign names to data

type emotion = 
    | joy = 0
    | fear = 1
    | anger = 2

let enum_stuff() =
    let my_feeling = emotion.joy

    match my_feeling with
    | joy -> printfn "I'm joyful"
    | fear -> printfn "I'm fearful"
    | anger -> printfn "I'm angry"




list_stuff()

Console.ReadKey() |> ignore
