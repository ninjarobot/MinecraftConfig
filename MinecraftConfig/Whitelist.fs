namespace MinecraftConfig

open System.Text.Json

type Username =
    {
        Name : string
        Uuid : string
    }

[<AutoOpen>]
module Whitelist =
    [<Literal>]
    let Filename = "whitelist.json"

    let format (whitelist:Username seq) =
        let options = JsonSerializerOptions(PropertyNamingPolicy=JsonNamingPolicy.CamelCase, WriteIndented=true)
        JsonSerializer.Serialize (whitelist, options)

    let writeWhitelist (whitelist:Username seq) =
        System.IO.File.WriteAllText (Filename, whitelist |> format)
