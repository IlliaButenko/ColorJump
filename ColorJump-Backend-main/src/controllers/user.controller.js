const UserModel = require('../models/user.model');
const HttpException = require('../utils/HttpException.utils');
const { validationResult } = require('express-validator');
const bcrypt = require('bcryptjs');
const jwt = require('jsonwebtoken');
const dotenv = require('dotenv');
dotenv.config();
/******************************************************************************
 *                              User Controller
 ******************************************************************************/
class UserController {

    signup = async (req, res, next) => {
        const username=req.body.username;
        const email =req.body.email_address;
        const password=req.body.password;

        console.log(username+'  '+email+'   '+password);
        const user_exist=await UserModel.find({ username:username});
        console.log(user_exist)
        if(user_exist[0]==undefined)
        {
            const result = await UserModel.insertMany({username:username,password:password,email:email});
            if (!result) {
                res.json({
                    success: -1
                });
            }
    
            res.json({
                success: 1
            });
        }
        else{
            res.json({
                success: 0
            });    
        }       
                
    };
    

    login = async (req, res, next) => {
        const email =req.body.email_address;
        const password=req.body.password;
        const emailExist=await UserModel.find({ email:email});
        if(emailExist[0]==undefined)
        {            
            res.json({
                success: -1
            });
        }
        else
        {
            const confirmPassword = await UserModel.find({ password:password});
            if(confirmPassword[0]==undefined){
                res.json({
                    success: 0
                }); 
            }
            else{
                res.json({
                    success: 1
                });
            }
        }            
    }
    
}


/******************************************************************************
 *                               Export
 ******************************************************************************/
module.exports = new UserController;