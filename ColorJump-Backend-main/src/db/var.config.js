const  {config} = require('dotenv');

config();

const vars = {
    env: process.env.NODE_ENV,
    baseUrl: process.env.BASE_URL,
    port: process.env.PORT,
    jwtSecret: process.env.JWT_SECRET,
    jwtExpirationInterval: process.env.JWT_EXPIRATION_MINUTES,
    mongo: {
        uri: process.env.NODE_ENV === 'development' ? process.env.MONGO_URI_TESTS : process.env.MONGO_URI,
    },
    mailUser: process.env.SMTP_USER,
    mailPwd: process.env.SMTP_PASSWORD,
    mailHost: process.env.SMTP_SERVER,
    mailPort: process.env.SMTP_PORT,
    supportEmail: process.env.SMTP_SUPPORT_EMAIL,
}

module.exports = vars;
