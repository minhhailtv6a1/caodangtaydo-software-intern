# services/resume_generator.py

import json

from services.prompt_builder import PromptBuilder
from services.llm_service import LLMService


class ResumeGenerator:

    def __init__(
        self,
        prompt_builder: PromptBuilder,
        llm_service: LLMService
    ):
        self.prompt_builder = prompt_builder
        self.llm_service = llm_service

    def generate(
        self,
        student_data: dict,
        output_json: str
    ) -> dict:

        prompt = self.prompt_builder.build(student_data)

        resume = self.llm_service.generate(prompt)

        with open(
            output_json,
            "w",
            encoding="utf-8"
        ) as f:

            json.dump(
                resume,
                f,
                indent=4,
                ensure_ascii=False
            )

        return resume