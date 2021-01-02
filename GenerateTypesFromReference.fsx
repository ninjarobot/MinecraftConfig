open System.IO
open System.Text.RegularExpressions

let onlyAlphaNum (setting:string) =
    let rgx = Regex("[^a-zA-Z0-9]")
    rgx.Replace(setting, "")

let formatName (name:string) =
    let rgx = Regex("[^a-zA-Z0-9]")
    rgx.Split(name)
    |> Seq.map System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase
    |> String.concat ""

let formatType (s:string) =
    match s with
    | s when s.StartsWith "string" -> "string"
    | s when s.StartsWith "integer" -> "int"
    | s when s.StartsWith "boolean" -> "bool"
    | _ -> "obj"
    
let parse (line:string) =
    let tokens = line.Split null
    (formatName tokens.[0]), (formatType tokens.[1]), tokens.[0]

printfn "module ServerProperties ="
printfn "    type ServerProperty ="

"JavaEditionReference.txt" |> File.ReadAllLines
|> Seq.map parse
|> Seq.iter (fun (n,t,f) -> printfn "        | %s of %s" n t)

printfn ""
printfn "    let format = function"

"JavaEditionReference.txt" |> File.ReadAllLines
|> Seq.map parse
|> Seq.iter (fun (n,t,f) -> printfn "        | %s value -> $\"%s={value}\"" n f)
