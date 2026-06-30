# services/template_engine.py

from pathlib import Path

from jinja2 import Template


class TemplateEngine:

    def __init__(
        self,
        template_path: str
    ):
        self.template_path = Path(template_path)

    def render(
        self,
        resume_data: dict,
        output_path: str
    ):

        with open(
            self.template_path,
            "r",
            encoding="utf-8"
        ) as f:

            template = Template(f.read())

        markdown = template.render(
            **resume_data
        )

        with open(
            output_path,
            "w",
            encoding="utf-8"
        ) as f:

            f.write(markdown)