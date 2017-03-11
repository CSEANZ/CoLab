The files included here represent the Logic Apps used to process the incoming data from both Streaming Analytics and any telemetry posted from the different teams.

[CoLabBrickProcessor](CoLabBrickProcessor) - Retrieves information posted about Lego bricks used for song composition.
[CoLabHappinessProcessor](CoLabHappinessProcessor) - Retrieves a sliding window of the current happiness of people in the video stream as determined by Azure Cognitive APIs.
[CoLabSongProcessor](CoLabSongProcessor) - Retrieves the current song being played by the DJ Studio.
[CoLabTetrisProcessor](CoLabTetrisProcessor) - Provides the current tetris piece that has been captured by the Kinect in !Tetris.
[run.csx](run.csx) - An Azure function that was required to cleanup the output from Streaming Analytics so it could be processed in a Logic App.

