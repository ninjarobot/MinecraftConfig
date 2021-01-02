namespace MinecraftConfig

open System.Text.Json

module Ops =
    [<Literal>]
    let Filename = "ops.json"

    type OperatorLevel =
        | Level1 = 1
        | Level2 = 2
        | Level3 = 3
        | Level4 = 4

    type Operator =
        {
            Name : string
            Uuid : string
            Level : OperatorLevel
        }

    let format (ops:Operator seq) =
        let options = JsonSerializerOptions(PropertyNamingPolicy=JsonNamingPolicy.CamelCase, WriteIndented=true)
        JsonSerializer.Serialize (ops, options)

    let writeOps (ops:Operator seq) =
        System.IO.File.WriteAllText (Filename, ops |> format)
