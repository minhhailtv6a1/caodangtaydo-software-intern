# {{ name }}

## {{ title }}

---

# Professional Summary

{{ summary }}

---

# Technical Skills

### Programming Languages

{% for item in technical_skills.languages %}

- {{ item }}
  {% endfor %}

### Frameworks

{% for item in technical_skills.frameworks %}

- {{ item }}
  {% endfor %}

### Databases

{% for item in technical_skills.databases %}

- {{ item }}
  {% endfor %}

### Tools

{% for item in technical_skills.tools %}

- {{ item }}
  {% endfor %}

### Concepts

{% for item in technical_skills.concepts %}

- {{ item }}
  {% endfor %}

---

# Projects

{% for project in projects %}

## {{ project.title }}

**Role:** {{ project.role }}

{{ project.description }}

**Technologies Used**

{% for tech in project.technologies %}

- {{ tech }}
  {% endfor %}

**Key Contributions**

{% for contribution in project.key_contributions %}

- {{ contribution }}
  {% endfor %}

---

{% endfor %}

# Education

{% for edu in education %}

## {{ edu.degree }}

**Major:** {{ edu.major }}

**GPA:** {{ edu.gpa }}

### Relevant Courses

{% for course in edu.courses %}

- {{ course }}
  {% endfor %}

---

{% endfor %}

# Certifications

{% for cert in certifications %}

- {{ cert }}
  {% endfor %}

---

# Career Objective

{{ career_objective }}
