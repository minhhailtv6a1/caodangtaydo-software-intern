# services/llm_service.py

import json
from openai import OpenAI


class LLMService:

    def __init__(
        self,
        api_key: str,
        model: str = "gpt-4o-mini"
    ):
        self.client = OpenAI(api_key=api_key)
        self.model = model

    def generate(self, prompt: str) -> dict:
        """
        Send prompt to LLM.

        Returns:
            dict
        """

        response = self.client.chat.completions.create(
            model=self.model,
            messages=[
                {
                    "role": "user",
                    "content": prompt
                }
            ],
            temperature=0.3
        )

        content = response.choices[0].message.content

        return json.loads(content)