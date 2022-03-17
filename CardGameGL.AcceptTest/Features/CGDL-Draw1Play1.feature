Feature: Draw one, play one - defined in CGDL

A very simple draw one play one card game
where none of the cards has any effect! How fun!

Background: Load a game
	Given the following "game" definition:
"""
CreateDeck "deck"
CreateDeck "discard pile"
CreateHand "player"
CreateCard "pass"
AddCard "pass" "deck"
Play DrawCard "deck" "player"
Play PlayCard "player" "discard pile"
"""
	When the definition "game" is processed
	Then the "player" should have 0 cards
	
Scenario: Draw a card
	When the player choses DrawCard
	Then the "player" should have 1 card

Scenario: Play a card
	Given the player has chosen DrawCard
	When the player choses PlayCard
	Then the "player" should have 0 cards