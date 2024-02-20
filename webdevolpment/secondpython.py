def print_colored_text(text, color_code):
    print(f"\033[{color_code}m{text}\033[0m")

message = "What is this"

colors = {
    "red": 31,
    "green": 32,
    "yellow": 33,
    "blue": 34,
    "magenta": 35,
    "cyan": 36,
}

for color_name, color_code in colors.items():
    colored_message = f"\033[{color_code}m{message}\033[0m"
    print(f"{color_name.capitalize()}: {colored_message}")
