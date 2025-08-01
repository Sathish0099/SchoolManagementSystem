
# Multi-Pose Human Face Matching Automatic Attendance System Using Deep Learning

## Project Overview

This project implements an advanced **automatic attendance system** using **multi-pose human face recognition** powered by deep learning techniques. The system leverages the **SeetaFace6Sharp** framework to detect, recognize, and verify faces in real-time, enabling accurate attendance marking without manual intervention. It supports various face poses and lighting conditions to improve recognition accuracy.

## Features

- Real-time face detection and recognition using deep learning.
- Multi-pose face matching to handle different facial orientations.
- User information retrieval and storage alongside attendance data.
- Attendance data stored securely in a SQL database.
- Image capturing and saving for verification and record keeping.
- Friendly user interface built with Windows Forms (WinForms).
- Export attendance records to CSV format.
- Integration of face detection and recognition models for modularity.
- Ability to start and stop camera feed with live preview.
- Scalable architecture for future web-based or mobile adaptations.

## Technologies Used

- **C#** (.NET Framework) — Core programming language for the application.
- **SeetaFace6Sharp** — Open-source deep learning face recognition library.
- **AForge.NET** — For camera feed and image capturing.
- **SkiaSharp** — For drawing rectangles and overlaying face information.
- **SQL Server / MySQL** — Database backend to store attendance and user data.
- **Windows Forms** — Desktop GUI framework.
- **CSV Export** — For exporting attendance data.
- **Deep Learning Models** — Face detection, recognition.

## System Architecture

1. **Face Detection Model**: Detects faces in the camera feed.
2. **Face Recognition Model**: Matches detected faces against the registered database
3. **Database Layer**: Stores user profiles and attendance logs.
4. **UI Layer**: Provides user interaction through camera preview, saving images, and attendance reporting.

## Installation and Setup

1. Clone the repository.
2. Install required dependencies, including SeetaFace6Sharp and AForge.NET libraries.
3. Setup the SQL database and import the provided schema.
4. Build and run the WinForms application.
5. Register users by capturing their facial images.
6. Start the attendance marking process by activating the camera feed.

## Usage

- Launch the application.
- Click **Start** to open the camera feed.
- The system will automatically detect and recognize faces.
- Recognized faces will be marked present with timestamp stored in the database.
- Use **Save Image** to capture and save the face image locally.
- Use **Stop** to end the camera feed.
- Export attendance logs using the **Export CSV** button.

## Future Improvements

- Expand to web and mobile platforms using ASP.NET and Xamarin.
- Enhance multi-pose face recognition with more training data.
- Add multi-user login with role-based access.
- Implement cloud storage for attendance records.
- Integrate real-time alerts and notifications for absentees.

## Contributing

Contributions are welcome! Please fork the repository and create pull requests for any improvements or bug fixes.

