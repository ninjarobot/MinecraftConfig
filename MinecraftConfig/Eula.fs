namespace MinecraftConfig

open System

type Agree = bool

[<AutoOpen>]
module Eula =
    [<Literal>]
    let Filename = "eula.txt"

    let format (agree:Agree) =
        let sb = System.Text.StringBuilder ()
        sb.AppendLine("#By changing the setting below to TRUE you are indicating your agreement to our EULA (https://account.mojang.com/documents/minecraft_eula).")
          .AppendLine($"""#{ DateTimeOffset.Now.ToString "R"}""")
          .AppendLine($"eula={agree}")
          .ToString()

    let writeEula (agree:Agree) =
        System.IO.File.WriteAllText (Filename, agree |> format)
