# services/prompt_builder.py

import json
from pathlib import Path


class PromptBuilder:
    """
    Build prompt for AI Resume Generation.

    Responsibilities:
    - Load prompt template
    - Inject student academic data
    """

    def __init__(self, prompt_path: str):
        self.prompt_path = Path(prompt_path)

    def load_template(self) -> str:
        """
        Load prompt template from file.
        """
        return self.prompt_path.read_text(encoding="utf-8")

    def build(self, student_data: dict) -> str:
        """
        Inject student academic data into prompt template.
        """

        student_json = json.dumps(
            student_data,
            indent=4,
            ensure_ascii=False
        )

        template = self.load_template()

        return template.replace(
            "{{student_data}}",
            student_json
        )