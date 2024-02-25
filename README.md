
# AdsML Project

AdsML is an ASP.NET Core Web API project integrated with ML.NET to predict whether a given message is an advertisement or not. This project aims to provide a simple yet effective solution for identifying advertisements within text messages, enabling applications to filter out unwanted content.

## Features

- **Machine Learning Model**: Utilizes ML.NET to train a model for predicting whether a message contains advertisement content.
- **ASP.NET Core Web API**: Provides an API endpoint for users to send messages and receive predictions on whether they are ads or not.
- **Integration**: Seamlessly integrates ML.NET into the ASP.NET Core Web API for real-time predictions.

## Usage
Once the application is running, you can interact with the API by sending HTTP POST requests to the /predict endpoint with a JSON payload containing the message you want to classify. The API will respond with a prediction indicating whether the message is classified as an ad or not.

    {
        "content": "تست"
    }

## Contributing
Contributions to AdsML are welcome! If you have any ideas for improvements, new features, or bug fixes, feel free to submit a pull request. For major changes, please open an issue first to discuss the proposed changes.
