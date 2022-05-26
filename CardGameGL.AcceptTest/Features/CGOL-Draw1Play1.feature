Feature: Draw one, play one - defined in CGOL

A very simple draw one play one card game
where none of the cards has any effect! How fun!

Background: Load a game
	Given the following:
"""
CreateDeck "deck"
CreateDeck "discard pile"
CreateHand "player"
CreateCard "pass"
AddCard "pass" "deck"
Play DrawCard "deck" "player"
Play PlayCard "player" "discard pile"
"""
	Then the "deck" should have 1 card
	And the "player" should have 0 card
	
Scenario: Draw a card
	When the player choses DrawCard
	Then the "player" should have 1 card

Scenario: Play a card
	Given the player has chosen DrawCard
	When the player choses PlayCard
	Then the "player" should have 0 cards