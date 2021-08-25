Feature: Wallbox technical challenge

    Write a test plan for the given API Rest

    Scenario: Get charger from CRUD service
        Given Set credentials
        When Set variables
        Then Charger should be retrieved

    Scenario: Get charger from CRUD service with invalid credentials
        Given Set invalid credentials
        When Set variables
        Then Charger should not be retrieved

    Scenario: Get charger from CRUD service with invalid variables
        Given Set credentials
        When Set invalid variables
        Then Charger should not be retrieved   