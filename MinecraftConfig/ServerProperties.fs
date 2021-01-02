namespace MinecraftConfig

module ServerProperties =
    [<Literal>]
    let Filename = "server.properties"

    type ServerProperty =
        | AllowFlight of bool
        | AllowNether of bool
        | BroadcastConsoleToOps of bool
        | BroadcastRconToOps of bool
        | Difficulty of string
        | EnableCommandBlock of bool
        | EnableJmxMonitoring of bool
        | EnableRcon of bool
        | SyncChunkWrites of bool
        | EnableStatus of bool
        | EnableQuery of bool
        | EntityBroadcastRangePercentage of int
        | ForceGamemode of bool
        | FunctionPermissionLevel of int
        | Gamemode of string
        | GenerateStructures of bool
        | GeneratorSettings of string
        | Hardcore of bool
        | LevelName of string
        | LevelSeed of string
        | LevelType of string
        | MaxBuildHeight of int
        | MaxPlayers of int
        | MaxTickTime of int
        | MaxWorldSize of int
        | Motd of string
        | NetworkCompressionThreshold of int
        | OnlineMode of bool
        | OpPermissionLevel of int
        | PlayerIdleTimeout of int
        | PreventProxyConnections of bool
        | Pvp of bool
        | QueryPort of int
        | RateLimit of int
        | RconPassword of string
        | RconPort of int
        | ResourcePack of string
        | ResourcePackSha1 of string
        | RequireResourcePack of bool
        | ServerIp of string
        | ServerPort of int
        | SnooperEnabled of bool
        | SpawnAnimals of bool
        | SpawnMonsters of bool
        | SpawnNpcs of bool
        | SpawnProtection of int
        | TextFilteringConfig of obj
        | UseNativeTransport of bool
        | ViewDistance of int
        | WhiteList of bool
        | EnforceWhitelist of bool

    let format = function
        | AllowFlight value -> $"allow-flight={value}" 
        | AllowNether value -> $"allow-nether={value}" 
        | BroadcastConsoleToOps value -> $"broadcast-console-to-ops={value}" 
        | BroadcastRconToOps value -> $"broadcast-rcon-to-ops={value}" 
        | Difficulty value -> $"difficulty={value}" 
        | EnableCommandBlock value -> $"enable-command-block={value}" 
        | EnableJmxMonitoring value -> $"enable-jmx-monitoring={value}" 
        | EnableRcon value -> $"enable-rcon={value}" 
        | SyncChunkWrites value -> $"sync-chunk-writes={value}" 
        | EnableStatus value -> $"enable-status={value}" 
        | EnableQuery value -> $"enable-query={value}" 
        | EntityBroadcastRangePercentage value -> $"entity-broadcast-range-percentage={value}" 
        | ForceGamemode value -> $"force-gamemode={value}" 
        | FunctionPermissionLevel value -> $"function-permission-level={value}" 
        | Gamemode value -> $"gamemode={value}" 
        | GenerateStructures value -> $"generate-structures={value}" 
        | GeneratorSettings value -> $"generator-settings={value}" 
        | Hardcore value -> $"hardcore={value}" 
        | LevelName value -> $"level-name={value}" 
        | LevelSeed value -> $"level-seed={value}" 
        | LevelType value -> $"level-type={value}" 
        | MaxBuildHeight value -> $"max-build-height={value}" 
        | MaxPlayers value -> $"max-players={value}" 
        | MaxTickTime value -> $"max-tick-time={value}" 
        | MaxWorldSize value -> $"max-world-size={value}" 
        | Motd value -> $"motd={value}" 
        | NetworkCompressionThreshold value -> $"network-compression-threshold={value}" 
        | OnlineMode value -> $"online-mode={value}" 
        | OpPermissionLevel value -> $"op-permission-level={value}" 
        | PlayerIdleTimeout value -> $"player-idle-timeout={value}" 
        | PreventProxyConnections value -> $"prevent-proxy-connections={value}" 
        | Pvp value -> $"pvp={value}" 
        | QueryPort value -> $"query.port={value}" 
        | RateLimit value -> $"rate-limit={value}" 
        | RconPassword value -> $"rcon.password={value}" 
        | RconPort value -> $"rcon.port={value}" 
        | ResourcePack value -> $"resource-pack={value}" 
        | ResourcePackSha1 value -> $"resource-pack-sha1={value}" 
        | RequireResourcePack value -> $"require-resource-pack={value}" 
        | ServerIp value -> $"server-ip={value}" 
        | ServerPort value -> $"server-port={value}" 
        | SnooperEnabled value -> $"snooper-enabled={value}" 
        | SpawnAnimals value -> $"spawn-animals={value}" 
        | SpawnMonsters value -> $"spawn-monsters={value}" 
        | SpawnNpcs value -> $"spawn-npcs={value}" 
        | SpawnProtection value -> $"spawn-protection={value}" 
        | TextFilteringConfig value -> $"text-filtering-config={value}" 
        | UseNativeTransport value -> $"use-native-transport={value}" 
        | ViewDistance value -> $"view-distance={value}" 
        | WhiteList value -> $"white-list={value}" 
        | EnforceWhitelist value -> $"enforce-whitelist={value}" 

    let writeServerProperties (properties:ServerProperty seq) =
        System.IO.File.WriteAllLines (Filename, properties |> Seq.map format)
    
    let defaultProperties =
        [
            SpawnProtection 16
            MaxTickTime 60000
            QueryPort 25565
            SyncChunkWrites true
            ForceGamemode false
            AllowNether true
            EnforceWhitelist true
            Gamemode "creative"
            BroadcastConsoleToOps true
            EnableQuery false
            PlayerIdleTimeout 0
            Difficulty "easy"
            SpawnMonsters true
            BroadcastRconToOps true
            OpPermissionLevel 4
            Pvp true
            EntityBroadcastRangePercentage 100
            SnooperEnabled true
            LevelType "default"
            Hardcore false
            EnableStatus true
            EnableCommandBlock false
            MaxPlayers 20
            NetworkCompressionThreshold 256
            MaxWorldSize 29999984
            FunctionPermissionLevel 2
            RconPort 16940
            ServerPort 16930
            SpawnNpcs true
            AllowFlight true
            LevelName "world"
            ViewDistance 10
            SpawnAnimals true
            WhiteList true
            GenerateStructures true
            OnlineMode true
            MaxBuildHeight 256
            PreventProxyConnections false
            UseNativeTransport true
            EnableJmxMonitoring false
            RateLimit 0
            Motd "My Minecraft Server"
            EnableRcon false
        ] |> List.sortBy format
