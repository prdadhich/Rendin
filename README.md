# Rendin


Overview

This prototype demonstrates a mobile AR workflow for capturing and reviewing defects in a physical environment.
Users can walk through a space, place defect markers in 3D, attach notes and photos, and then review all issues in a spatially contextualized way.

The goal is to support renovation quoting and contractor handoff by providing where, what, and visual evidence of each defect.

Platform & Stack

Device tested: Android phone (ARCore supported)

Unity: 6.3

XR: AR Foundation + ARCore

Language: C#

Build target: Android (.apk)

Features
Scan Mode

Real-time AR camera with plane detection

Tap on a wall, floor, or surface to place a defect marker

Each defect stores:

3D position (AR space)

Photo (captured at placement time)

Short text description

Review Mode

List of all captured defects with photos and notes

Spatial markers remain visible in the real environment

Designed for client → contractor handoff during the same site visit

How to Run

Open the project in Unity 6.3

Switch Build Target to Android

Ensure ARCore XR Plugin is enabled

Install Google Play Services for AR on your phone

Build and install the APK

Launch the app and point the camera at textured surfaces for plane detection

Assumptions & Limitations

This is an intentionally time-boxed PoC.

Defect anchors are session-bound

Scan and Review are expected to happen in the same visit

No persistent room mapping or cloud anchors were implemented

No room mesh or LiDAR reconstruction

The prototype focuses on defect localization, not full 3D scanning

UI layout is functional but not production-polished

The emphasis is on spatial workflow and AR interaction, not final UI design