module Bandwagoner

type Coach = { Name: string; FormerPlayer: bool; }
type Stats = { Wins: int; Losses: int }
type Team = { Name: string; Coach: Coach; Stats: Stats }

let createCoach (name: string) (formerPlayer: bool): Coach =
    let coach: Coach = { Name = name; FormerPlayer = formerPlayer }
    coach

let createStats(wins: int) (losses: int): Stats =
   let stats: Stats = { Wins = wins; Losses = losses }
   stats

let createTeam(name: string) (coach: Coach)(stats: Stats): Team =
  failwith "Please implement the 'createTeam' function"

let replaceCoach(team: Team) (coach: Coach): Team =
   failwith "Please implement the 'replaceCoach' function"

let isSameTeam(homeTeam: Team) (awayTeam: Team): bool =
   failwith "Please implement the 'isSameTeam' function"

let rootForTeam(team: Team): bool =
   failwith "Please implement the 'rootForTeam' function"
