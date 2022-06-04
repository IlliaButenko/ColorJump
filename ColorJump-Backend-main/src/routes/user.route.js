const express = require('express');
const router = express.Router();
const userController = require('../controllers/user.controller');
const scoreController = require('../controllers/scoreController');
const auth = require('../middleware/auth.middleware');
const Role = require('../utils/userRoles.utils');
const awaitHandlerFactory = require('../middleware/awaitHandlerFactory.middleware');

const { validateLogin } = require('../middleware/validators/userValidator.middleware');

router.post('/bestScore', validateLogin, awaitHandlerFactory(userController.signup)); // localhost:3000/api/v1/users/login
router.post('/signup', validateLogin, awaitHandlerFactory(userController.signup)); // localhost:3000/api/v1/users/login
router.post('/login', validateLogin, awaitHandlerFactory(userController.login)); // localhost:3000/api/v1/users/login
module.exports = router;