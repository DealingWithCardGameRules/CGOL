Feature: Draw one, Play one game

A very simple draw one play one card game
where none of the cards has any effect! How fun!

Background: 
	Given a discard pile

Scenario: Draw a card
	Given a deck of 1 card
	And a player with 0 cards
	When the player draws 1 card
	Then the player should have 1 card

Scenario: Play a card
	Given a player with 1 card
	When the player plays 1 card
	Then the player should have 0 card