To run the model:

python ml_lib/speech_commands/label_wav.py \
--graph=ml_lib/trained_model/conv_actions_frozen.pb \
--labels=ml_lib/trained_model/conv_actions_labels.txt \
--wav=user_input_sound.wav


model will print three most possible answers and the possibility of each. See run_graph() in label_wav file.