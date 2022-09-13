open System
open System.IO

type PowerSystem =
  | System of string * int
  | Junction of string * List<PowerSystem>

let Starship =
  Junction("Core", 
    [ 
      Junction("Users",
            [
            System("Main Computer",-10);
            System("Library Computer",-10);
            Junction("Defence",
              [
                Junction("Shields",
                  [
                    System("Forward Shields",-50);
                    System("Side Shields",-100);
                    System("Top Shields",-25);
                    System("Bottom Shields",-30);
                    System("Aft Shields",-120)
                  ]);
                System("Anti-Tractor Beam",-20);
                System("Cloaking",-300)
              ]);
            Junction("Offence",
              [
                Junction("Phasers",
                  [
                    System("Port Phasers",-50);
                    System("Starboard Phasers",-50);
                    System("Aft Phasers",-30)
                  ]);
                Junction("Torpedos",
                  [
                    System("Forward Torpedos",-15);
                    System("Aft Torpedos",-15)
                  ])
              ])
        ]); 
      Junction("Generators",
        [
          Junction("Main Reactors",
            [
              System("Port Reactor",750);
              System("Starboard Reactor",1100)
            ]);
          Junction("Impulse Engines",
            [
              System("Main Impulse Engine",250);
              System("Secondary Impulse Engine",100)
            ]);
          System("Auxiliary Power Unit",250);
          System("Stolen Alien Reactor",220)
        ])
    ]
  )


let rec getElementPow (starShip:PowerSystem) =
    match starShip with
    | System(name, power)   -> power
    | Junction(name, alist)  -> splitList alist
and splitList (theList: List<PowerSystem>) =
    match theList with 
    | head::tail -> (getElementPow head) + (splitList tail)
    | [] -> 0

//task 2

let rec JunctionPath pSystem sName (aPath:List<string>) = 
    match pSystem with
    | System(name, aNumber) -> if name = sName then aPath             // Could use System.String.Equals function with third param System.StringComparison.CurrentCultureIgnoreCase instead of = to ignore case
                               else []
    | Junction(name, aList) -> SplitList2 aList sName (aPath@[name])  // Last param NEEDS TO BE IN BRACKETS!!!

and SplitList2 list sName aPath = 
    match list with
    | [] -> []
    | head::tail -> (JunctionPath head sName aPath)@(SplitList2 tail sName aPath)

//task 3

let rec comparePath (path1:List<string>) (path2:List<string>) (junc:string) =
    match path1 with
    | []        -> junc
    | head::tail -> if head = path2.Head then comparePath tail path2.Tail head else junc


let CommonPath pSystem system1 system2 =
   let path1 = (JunctionPath pSystem system1 [])
   let path2 = (JunctionPath pSystem system2 [])

   printfn "%A" path1
   printfn "%A" (path2)

   if (List.length(path1) > List.length(path2)) then comparePath path2 path1 "Error"
    else comparePath path1 path2 "Error"
    


open System

[<EntryPoint>]
let main argv =
    printfn "%A" (JunctionPath Starship "Port Phasers" [])
    printfn "%A" (CommonPath Starship "Port Phasers" "Main Computer")
    0 // return an integer exit code
