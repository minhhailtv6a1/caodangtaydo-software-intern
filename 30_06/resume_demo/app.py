import json
import streamlit as st

from main import generate_resume

st.set_page_config(
    page_title="AI Resume Generator",
    layout="wide"
)

st.title("🎓 AI Resume Generator")

uploaded_file = st.file_uploader(
    "Upload student.json",
    type=["json"]
)

if uploaded_file:

    student = json.load(uploaded_file)

    col1, col2 = st.columns(2)

    with col1:
        st.subheader("📄 Student Academic Data")
        st.json(student)

    if st.button("🚀 Generate Resume"):

        with st.spinner("Generating Resume..."):
            resume = generate_resume(student)

        with open(
            "output/resume.md",
            "r",
            encoding="utf-8"
        ) as f:
            markdown = f.read()

        with col2:
            st.subheader("📄 Generated Resume")
            st.markdown(markdown)

        st.download_button(
            "⬇ Download Resume.md",
            markdown,
            file_name="resume.md",
            mime="text/markdown"
        )