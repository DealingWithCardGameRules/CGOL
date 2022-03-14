Feature: Draw one, play one - defined in CGDL

A very simple draw one play one card game
where none of the cards has any effect! How fun!

Scenario: Draw a card
	Given the following "game" definition:
"""
CreateDeck "deck"
CreateHand "player"
CreateCard "Pass" "Pass" "Pass" "Does nothing"
AddCard "deck" "Pass"
DrawCard "deck" "player"
"""
	When the definition "game" is processed
	Then the "player" should have 1 card