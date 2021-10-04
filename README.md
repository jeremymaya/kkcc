# kkcc

![Actions Status](https://github.com/jeremymaya/kkcc/workflows/deploy/badge.svg)  

Author: Kyungrae Kim

Deployed Link: <https://kkcc.herokuapp.com>

## About This Project

This is a demo website built for Korean Kirkland Covenant Church.

Criteria for this demo includes:

* Make improvements from the [current website](https://kkcc.business.site/)
* Add ability to post and show sermons
* Come up with better way to post photos to share current events

---

## Project Log

### 10/3/2021

* Database changed from Microsoft SQL Server to Postgres
* Containerized to CI/CD to Heroku

### 2/8/2020

Basic layout completed.

All of the criterias needed to be fulfilled in a short amount of time and cost needs to be minimized. Also it needed to ensure minimal future maintainence.

To meet the criterias, the demo implements Google services as it offered the following:

* Bootstrap for clean appearance and ready to use components
* YouTube for free unlimited video hosting
* Google Photos for free unlimited image hosting

Building features around the services offered by Google was fairly smooth but working with Google Photos came as unxpected challenge since it did not offer any embeding services. This challenge was addressed by generating thumbnail image link by using [CTRLQ.org](https://ctrlq.org/google/photos/) and linking the album directly to the Google Photos album.

If this demo is approved to proceed forward, below features need to be discussed and worked on:

* Overall theme for the website
* Icon for navbar and favicon
* Image assests for the website (all hosted via Google Photos)
* Carousel image specifications
* Sermon class with the following properties:
  * Title
  * Speaker
  * Date
  * Link (YouTube)
* Album class
  * Title
  * Date
  * Thumbnail Link (generated via CTRLQ.org)
  * Link (Google Photos)
* Sermons and Albums page pagination
* Admin page to perform CRUD on Semons table and Albums table
* Website domain
* Discuss about how to manage Google Photos and YouTube

---

## Resource

* [colorlib.com](https://colorlib.com/preview/theme/reborn/contact.html)
* [Boostrap - Examples](https://getbootstrap.com/docs/4.1/examples/)
* [YouTube Data API - Videos](https://developers.google.com/youtube/v3/docs/videos/list)
* [Google Drive API - Files](https://developers.google.com/drive/api/v2/reference/files/list)
* [CTRLQ.org - Embed Google Photos](https://ctrlq.org/google/photos/)