Feature: Ordering Answers
	Answers must be ordered by some criteria

Scenario: The answwer with the highest vote gets to the top
	Given There is a question "Waht's your favorite colour" with the answers
		| Answer         | Votes |
		| Red            | 1	 |
		| Cucumber green | 1	 |
	When you upvote answer "Cucumber green"
	Then The answer "Cucumber green" should be on top
