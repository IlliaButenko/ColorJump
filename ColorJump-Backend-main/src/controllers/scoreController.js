const ScoreModel = require('../models/scoreModel');
const HttpException = require('../utils/HttpException.utils');
const { validationResult } = require('express-validator');
const bcrypt = require('bcryptjs');
const jwt = require('jsonwebtoken');
const dotenv = require('dotenv');
dotenv.config();

class ScoreController {

    recordScore = async (req, res, next) => {
        const username=req.body.username;
        const email =req.body.email_address;
        const bestScore=req.body.bestScore;

        console.log(username+email+bestScore)
        const result = await ScoreModel.insertMany({username:username,email:email, bestscore:bestScore});
        
    }
}


module.exports = new ScoreController;