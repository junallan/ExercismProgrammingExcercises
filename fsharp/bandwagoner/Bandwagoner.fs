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
  let team: Team = { Name = name; Coach = coach; Stats = stats }
  team

let replaceCoach(team: Team) (coach: Coach): Team =
   let team: Team = { team with Coach = coach }
   team

let isSameTeam(homeTeam: Team) (awayTeam: Team): bool =
   homeTeam = awayTeam

let rootForTeam(team: Team): bool =
   match team with
   | { Coach = {Name = "Gregg Popovich"} } -> true
   | { Coach = { FormerPlayer = true } } -> true
   | { Name = "Chicago Bulls" } -> true
   | _ when team.Stats.Wins >= 60 -> true
   | _ when team.Stats.Wins < team.Stats.Losses -> true
   | _ -> false
