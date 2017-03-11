# CoLab Processing Pipeline
The files included here represent the Logic Apps used to process the incoming data from both Streaming Analytics and any telemetry posted from the different teams.

The output of each Logic App is the insertion of a record into a accompanying table for each activity type. This is data is then visualised using Power BI embedded on the main dashboard.

Both the Logic App code and the output table's schema is provided below for each activity type.

# BrickCount Table

[CoLabBrickProcessor](CoLabBrickProcessor) - Retrieves information posted about Lego bricks used for song composition.

| COLUMN_NAME  | DATA_TYPE  | DESCRIPTION  |
|---|---|---|
|Id   |int   |A sequential identity.|
|Count   |float   |The amount of bricks being counted by the video processing and being reported to the dashboard.|
|TimeSubmitted   |datetime2   |The time the value was retrieved from the Service Bus queue and inserted into the database.|

# Song Table

[CoLabSongProcessor](CoLabSongProcessor) - Retrieves the current song being played by the DJ Studio.

| COLUMN_NAME  | DATA_TYPE  | DESCRIPTION  |
|---|---|---|
|Id   |int   |A sequential identity.|
|Name   |float   |The name and artist of the current song as a single string.|
|TimeSubmitted   |datetime2   |The time the value was retrieved from the Service Bus queue and inserted into the database.|

# Tetris Table

[CoLabTetrisProcessor](CoLabTetrisProcessor) - Provides the current tetris piece that has been captured by the Kinect in !Tetris.

| COLUMN_NAME  | DATA_TYPE  | DESCRIPTION  |
|---|---|---|
|Id   |int   |A sequential identity.|
|Shape   |float   |The URL to a blob container that contains the pictures of the available shapes that can be represented by a human body position.|
|TimeSubmitted   |datetime2   |The time the value was retrieved from the Service Bus queue and inserted into the database.|

# Happiness Table

[CoLabHappinessProcessor](CoLabHappinessProcessor) - Retrieves a sliding window of the current happiness of people in the video stream as determined by Azure Cognitive APIs.

[run.csx](run.csx) - An Azure function that was required to cleanup the output from Streaming Analytics so it could be processed in the CoLabHappinessProcessor Logic App. This was called inline from the CoLabHappinessProcessor Logic App.

| COLUMN_NAME  | DATA_TYPE  | DESCRIPTION  |
|---|---|---|
|Id   |int   |A sequential identity.|
|HappinessScore   |float   |The value between 0 and 1 returned by the Cognitive API to represent the average happiness of the people in the video being analysed.|
|TimeSubmitted   |datetime2   |The time the value was retrieved from the Service Bus queue and inserted into the database.|

All of the above Logic Apps are triggered by a Service Bus queue and output the resulting data to an Azure SQL database for reporting.


