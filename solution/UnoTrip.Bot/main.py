import os
import asyncio
import logging
from dotenv import load_dotenv

from globals import run_app

load_dotenv()
bot_token = os.getenv("BOT_TOKEN")

logging.basicConfig(level=logging.INFO)

if __name__ == "__main__":
    asyncio.run(run_app(bot_token))


# TODO: Сделать Filter Middleware, чтобы доступ был только мне
