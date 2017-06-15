﻿module Guaranteed.Program

open FsShelter
open Guaranteed.Topology
open Common

let exePath = System.Reflection.Assembly.GetEntryAssembly().Location

// management CLI and task execution entry point
[<EntryPoint>]
let main argv = 
    let cfg = [Conf.TOPOLOGY_MULTILANG_SERIALIZER, box "com.prolucid.protoshell.ProtoSerializer"
               Conf.TOPOLOGY_MAX_SPOUT_PENDING, box 123
               Conf.TOPOLOGY_DEBUG, box false] |> Conf.ofList

    match argv |> List.ofArray with
    | "submit"::address::[port] -> 
        Startup.submit sampleTopology exePath (Startup.mkWindowsArgs []) cfg address (int port) 
    | "submit-mono"::address::[port] -> 
        Startup.submit sampleTopology exePath (Startup.mkMonoArgs []) cfg address (int port)
    | ["submit-local"] -> 
        let mkArgs = if isNull (System.Type.GetType "Mono.Runtime") then Startup.mkWindowsArgs
                     else Startup.mkMonoArgs
        Startup.submit sampleTopology exePath (mkArgs []) cfg "localhost" Nimbus.DefaultPort
    | "kill"::address::[port] ->
        Nimbus.withClient address (int port) 
            (fun client -> Nimbus.kill client sampleTopology.Name)
    | ["graph"] ->
        sampleTopology
        |> DotGraph.writeToConsole
    | _ -> 
        sampleTopology
        |> Task.ofTopology
        |> Task.run ProtoIO.start
//        |> Task.runWith (string >> Logging.callbackLog)  ProtoIO.start // start using a traffic logger 
    0

